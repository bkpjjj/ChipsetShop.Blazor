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
    public class CatalogController : Controller
    {
        const int CommentPageSize = 5;
        private readonly DataContext dataContext;
        private readonly ILogger<CatalogController> logger;
        public CatalogController(DataContext data, ILogger<CatalogController> logger)
        {
            dataContext = data;
            this.logger = logger;
        }

        [Route("[action]")]
        public IActionResult Filters(string category, string s)
        {
            dataContext.Attributes.Include(x => x.AttributeSceme).Load();
            dataContext.Products.Include(x => x.Tags).Include(x => x.Attributes).Include(x => x.Pictures).Include(x => x.Category).Load();
            var data = dataContext.Products.ToList();

            if (!string.IsNullOrEmpty(category) && category != "all")
                data = data.Where(x => x.Category.MetaName == category).ToList();

            if (!string.IsNullOrEmpty(s))
                data = data.Where(
                    x => x.Name.Replace(" ", "").ToUpper().Contains(s.Replace(" ", "").ToUpper()) ||
                         x.Tags.Any(x => x.Name.Replace(" ", "").ToUpper().Contains(s.Replace(" ", "").ToUpper()))
                ).ToList();

            List<AttributeScemeModel> attributePoll = new List<AttributeScemeModel>();

            foreach (ProductModel p in data)
            {
                foreach (AttributeModel a in p.Attributes)
                {
                    if (!attributePoll.Contains(a.AttributeSceme))
                        attributePoll.Add(a.AttributeSceme);
                }
            }

            JAttributeModel[] jdata = new JAttributeModel[attributePoll.Count];
            for (int i = 0; i < attributePoll.Count; i++)
            {
                var checkbox = new JCheckboxAttributeModel();
                checkbox.Name = attributePoll[i].Name;
                checkbox.IsGeneral = attributePoll[i].IsGeneral;
                checkbox.Values = attributePoll[i].Attributes.Where(x => data.Contains(x.Product)).GroupBy(x => x.Value).Select(x => new JCheckboxValue() { Value = x.Key, Count = x.Count() });
                jdata[i] = checkbox;
            }

            return Json(jdata);
        }


        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> Comment([FromForm] string title, [FromForm] string dignity, [FromForm] string limitations, [FromForm] string text, [FromForm] string returnUrl, [FromForm] string product, [FromForm] int rate = 1)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account", new { ReturnUrl = returnUrl });
            }

            dataContext.Products.Include(x => x.Tags).Include(x => x.Attributes).Include(x => x.Pictures).Include(x => x.Category).Load();
            dataContext.Comments.Include(x => x.Product).Include(x => x.User).Load();

            ProductModel p = dataContext.Products.FirstOrDefault(x => x.MetaName == product);

            if (p is null)
                return BadRequest();

            dataContext.Comments.Add(new CommentModel()
            {
                Title = title,
                Dignity = dignity,
                Limitations = limitations,
                Text = text,
                Date = DateTime.Now,
                Product_Id = p.Id,
                User_Id = User.FindFirst(ClaimTypes.NameIdentifier).Value,
                Rate = rate
            });

            await dataContext.SaveChangesAsync();

            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }


        [Route("[action]")]
        [HttpGet()]
        public IActionResult Comments(string product, int page)
        {
            List<CommentModel> allComments = dataContext.Comments.Include(x => x.Product).Include(x => x.User).Where(x => x.Product.MetaName == product).OrderByDescending(x => x.Id).ToList();

            int commentsCount = allComments.Count;

            List<CommentModel> pageComments = allComments.Skip(CommentPageSize * (page - 1)).Take(CommentPageSize).ToList();

            JCommentsModel json_comments = new JCommentsModel();

            json_comments = new JCommentsModel()
            {
                Comments = pageComments.Select(x => new JCommentModel()
                {
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
                    }
                }),
                CommentsCount = commentsCount,
                CurrentPage = page,
                TotalRate = commentsCount <= 0 ? 0 : MathF.Round(allComments.Average(x => (float)x.Rate), 2),
                TotalPages = (int)MathF.Ceiling(commentsCount / (float)CommentPageSize),
            };

            var rates = new JRateModel[5];
            for (int i = 0; i < 5; i++)
            {
                rates[rates.Length - 1 - i].UserCount = allComments.Where(x => x.Rate == i + 1).Count();
                rates[rates.Length - 1 - i].Precentage = (int)(100 * (rates[rates.Length - 1 - i].UserCount / (float)allComments.Count));
            }
            json_comments.TotalRateDetail = rates;

            return Json(json_comments);
        }

        [Route("[action]")]
        public IActionResult Products(string category, string s, int page, [FromQuery(Name = "filters[]")] string[] filters, decimal? minPrise, decimal? maxPrise, int pageCount = 18, int sort = 0)
        {
            var data = dataContext.Products.Include(x => x.Tags).Include(x => x.Comments).Include(x => x.Attributes).Include(x => x.Pictures).Include(x => x.Category).ToList();

            if (!string.IsNullOrEmpty(category) && category != "all")
                data = data.Where(x => x.Category.MetaName == category).ToList();

            decimal pminPrise = 0;
            decimal pmaxPrise = 0;

            if (data.Count > 0)
            {
                pminPrise = data.Min(x => x.DicountPrise);
                pmaxPrise = data.Max(x => x.DicountPrise);
            }

            if (filters.Length > 0)
                data = data.Where(x => filters.Any(f => x.Attributes.Any(a => a.Value == f))).ToList();

            if (!string.IsNullOrEmpty(s))
                data = data.Where(
                    x => x.Name.Replace(" ", "").ToUpper().Contains(s.Replace(" ", "").ToUpper()) ||
                         x.Tags.Any(x => x.Name.Replace(" ", "").ToUpper().Contains(s.Replace(" ", "").ToUpper()))
                ).ToList();

            foreach (ProductModel p in data)
            {
                p.ResetCache();
            }

            if (sort == 0)
                data = data.OrderByDescending(x => x.AvgRate).ToList();

            if (minPrise is not null && maxPrise is not null)
                data = data.Where(x => x.DicountPrise >= minPrise && x.DicountPrise <= maxPrise).ToList();

            JCatalogModel catalogModel = new JCatalogModel();
            catalogModel.TotalPages = (int)MathF.Ceiling(data.Count / (float)pageCount);
            catalogModel.ProductsCount = pageCount;
            catalogModel.TotalProducts = data.Count;
            catalogModel.MinPrise = pminPrise;
            catalogModel.MaxPrise = pmaxPrise;

            data = data.Skip(pageCount * (page - 1)).Take(pageCount).ToList();

            JProductModel[] jdata = new JProductModel[data.Count];
            int index = 0;
            foreach (ProductModel product in data)
            {
                jdata[index] = new JProductModel();
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
                        Prise = product.DicountPrise.ToString("#.##")
                    };
                }

                index++;
            }

            catalogModel.Products = jdata;
            catalogModel.CurrentPage = page;

            return Json(catalogModel);
        }
    }
}