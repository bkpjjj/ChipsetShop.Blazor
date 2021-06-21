using System.Linq;
using System;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using ChipsetShop.MVC.Models.Json;
using ChipsetShop.MVC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ChipsetShop.MVC.Models;
using ChipsetShop.MVC.Helpers;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace ChipsetShop.MVC.Api.Controllers
{
    [ApiController]
    [Area("api")]
    [Route("[area]/[controller]")]
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private readonly DataContext dataContext;
        private readonly ILogger<CatalogController> logger;
        public AdminController(DataContext data, ILogger<CatalogController> logger)
        {
            dataContext = data;
            this.logger = logger;
        }

        [HttpDelete]
        [Route("[action]")]
        public async Task<IActionResult> DeleteComment([FromForm]int id)
        {
            var comment = await dataContext.Comments.FindAsync(id);

            if(comment is null)
                return BadRequest();

            dataContext.Comments.Remove(comment);
            await dataContext.SaveChangesAsync();

            return Ok();
        }

        [Route("[action]")]
        [HttpGet()]
        public IActionResult Comments(string user_id, int page)
        {
            dataContext.Products.Include(x => x.Category).Load();
            List<CommentModel> allComments = dataContext.Comments.Include(x => x.Product).Include(x => x.User).ToList();

            int commentsCount = allComments.Count;

            if (!string.IsNullOrEmpty(user_id))
                allComments = allComments.Where(x => x.User_Id == user_id).ToList();

            List<CommentModel> pageComments = allComments.Skip(20 * (page - 1)).Take(20).ToList();


            JAdminCommentsModel json_comments = new JAdminCommentsModel()
            {
                Comments = pageComments.Select(x => new JAdminCommentModel()
                {
                    Id = x.Id,
                    Text = x.Text,
                    Title = x.Title,
                    Dignity = x.Dignity,
                    Limitations = x.Limitations,
                    Date = x.Date.ToString(@"dd\.MM\.yyyy в hh\:mm"),
                    Rate = x.Rate,
                    User = new JUserModel()
                    {
                        Email = x.User.Email,
                        Login = x.User.UserName
                    },
                    Product = new JAdminCommentModel.JAdminProductModel()
                    {
                        Key = x.Product.MetaName,
                        Url = "/catalog/" + x.Product.Category.MetaName + "/" + x.Product.MetaName
                    }
                }),
                CommentsCount = commentsCount,
                CurrentPage = page,
                TotalPages = (int)MathF.Ceiling(commentsCount / 20.0f),
            };

            return Json(json_comments);
        }

        [Route("[action]")]
        [HttpGet]
        public IActionResult Products(string category, string s, int avgRate, bool isNew, bool InStock, bool discount, int page)
        {
            var data = dataContext.Products.Include(x => x.Tags).Include(x => x.Comments).Include(x => x.Attributes).Include(x => x.Pictures).Include(x => x.Category).ToList();

            if (!string.IsNullOrEmpty(category) && category != "all")
                data = data.Where(x => x.Category.MetaName == category).ToList();

            if (!string.IsNullOrEmpty(s))
                data = data.Where(
                    x => x.Name.Replace(" ", "").ToUpper().Contains(s.Replace(" ", "").ToUpper()) ||
                         x.Tags.Any(x => x.Name.Replace(" ", "").ToUpper().Contains(s.Replace(" ", "").ToUpper()))
                ).ToList();

            if (discount)
                data = data.Where(x => x.Discount > 0).ToList();

            if (isNew)
                data = data.Where(x => x.IsNew).ToList();

            if (InStock)
                data = data.Where(x => x.InStock).ToList();


            foreach (ProductModel p in data)
            {
                p.ResetCache();
            }

            if (avgRate > 0)
                data = data.Where(x => Math.Round(x.AvgRate) == avgRate).ToList();

            JAdminCatalogModel catalogModel = new JAdminCatalogModel();
            catalogModel.TotalPages = (int)MathF.Ceiling(data.Count / (float)40);
            catalogModel.TotalProducts = data.Count;

            data = data.Skip(40 * (page - 1)).Take(40).ToList();

            JAdminProductModel[] jdata = new JAdminProductModel[data.Count];
            int index = 0;
            foreach (ProductModel product in data)
            {
                jdata[index] = new JAdminProductModel();
                jdata[index].Id = product.Id;
                jdata[index].Name = product.Name;
                jdata[index].Key = product.MetaName;
                jdata[index].Tags = string.Join(" ,", product.Tags);
                jdata[index].Prise = product.Prise.ToString("#.##");
                jdata[index].InStock = product.InStock;
                jdata[index].Category = product.Category.Name;
                jdata[index].Icon = product.Pictures.First().ImageSource;
                jdata[index].Url = "/catalog/" + product.Category.MetaName + "/" + product.MetaName;
                jdata[index].IsNew = product.IsNew;
                jdata[index].AvgRate = product.AvgRate;

                if (product.Discount > 0)
                {
                    jdata[index].Discount = new JDiscountModel()
                    {
                        Amount = (int)product.Discount,
                        Prise = (product.Prise - product.Prise * ((int)product.Discount / 100m)).ToString("#.##")
                    };
                }

                index++;
            }
            catalogModel.Categories = dataContext.Categories.Select(x => new JCategoryModel() { Key = x.MetaName, Name = x.Name });
            catalogModel.Products = jdata;
            catalogModel.CurrentPage = page;

            return Json(catalogModel);
        }

        [HttpDelete]
        [Route("[action]")]
        public async Task<IActionResult> DeleteProduct([FromForm]int id)
        {
            var product = await dataContext.Products.FindAsync(id);

            if(product is null)
                return BadRequest();

            dataContext.Products.Remove(product);
            await dataContext.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetUsers()
        {
            var users = dataContext.Users.ToList();
            var jusers = new List<JAdminUserModel>();
            foreach (var user in users)
            {
                jusers.Add(new JAdminUserModel() { Id = user.Id, Email = user.Email,Login = user.UserName });
            }

            return Json(jusers);
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetCategories()
        {
            var categories = dataContext.Categories.ToList();

            var data = new JAdminCategoryModel[categories.Count];

            int index = 0;
            foreach (var c in categories)
            {
                data[index] = new JAdminCategoryModel();
                data[index].Id = c.Id;
                data[index].Name = c.Name;
                data[index].Key = c.MetaName;
                data[index++].IconUrl = c.IconUrl;
            }

            return Json(data);
        }

        [HttpDelete]
        [Route("[action]")]
        public async Task<IActionResult> DeleteCategory([FromForm]int id)
        {
            var c = dataContext.Categories.Find(id);

            if(c is null)
                return BadRequest();

            dataContext.Categories.Remove(c);

            await dataContext.SaveChangesAsync();

            return Ok();
        }
    }
}