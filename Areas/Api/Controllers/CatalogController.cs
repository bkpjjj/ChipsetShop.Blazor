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
                checkbox.FieldType = attributePoll[i].FieldType;
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
                Date = new TimeSpan(DateTime.Now.Ticks),
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
            dataContext.Comments.Include(x => x.Product).Include(x => x.User).Load();

            List<CommentModel> comments = dataContext.Comments.Where(x => x.Product.MetaName == product).OrderByDescending(x => x.Id).ToList();

            JCommentsModel json_comments = new JCommentsModel();

            json_comments = new JCommentsModel()
            {
                Comments = comments.Select(x => new JCommentModel()
                {
                    Text = x.Text,
                    Title = x.Title,
                    Dignity = x.Dignity,
                    Limitations = x.Limitations,
                    Date = x.Date.ToString(@"d\.h\:mm\:ss"),
                    Rate = x.Rate,
                    User = new JUserModel()
                    {
                        Email = x.User.Email,
                        Login = x.User.UserName
                    }
                }),
                CommentsCount = comments.Count(),
                CurrentPage = page,
                TotalRate = comments.Count <= 0 ? 0 : MathF.Round(comments.Average(x => (float)x.Rate), 2),
                TotalPages = 1,
            };

            var rates = new JRateModel[5];
            for (int i = 0; i < 5; i++)
            {
                rates[rates.Length - 1 - i].UserCount = comments.Where(x => x.Rate == i + 1).Count();
                rates[rates.Length - 1 - i].Precentage = (int)(100 * (rates[rates.Length - 1 - i].UserCount / (float)comments.Count));
            }
            json_comments.TotalRateDetail = rates;

            return Json(json_comments);
        }

        [Route("[action]")]
        public IActionResult Products(string category, string s, int page, [FromQuery(Name = "filters[]")] string[] filters, int pageCount = 18, int sort = 0)
        {
            var sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            var data = dataContext.Products.Include(x => x.Tags).Include(x => x.Comments).Include(x => x.Attributes).Include(x => x.Pictures).Include(x => x.Category).ToList();
            sw.Stop();
            logger.LogInformation("Load data: " + sw.ElapsedMilliseconds + " ms.");
            sw.Restart();
            

            

            if (!string.IsNullOrEmpty(category) && category != "all")
                data = data.Where(x => x.Category.MetaName == category).ToList();

            logger.LogInformation("Sort category data: " + sw.ElapsedMilliseconds + " ms.");
            sw.Stop();
            sw.Restart();

            if (filters.Length > 0)
                data = data.Where(x => filters.Any(f => x.Attributes.Any(a => a.Value == f))).ToList();

            logger.LogInformation("Sort filters data: " + sw.ElapsedMilliseconds + " ms.");
            sw.Stop();
            sw.Restart();

            if (!string.IsNullOrEmpty(s))
                data = data.Where(
                    x => x.Name.Replace(" ", "").ToUpper().Contains(s.Replace(" ", "").ToUpper()) ||
                         x.Tags.Any(x => x.Name.Replace(" ", "").ToUpper().Contains(s.Replace(" ", "").ToUpper()))
                ).ToList();

            logger.LogInformation("Sort search data: " + sw.ElapsedMilliseconds + " ms.");
            sw.Stop();
            sw.Restart();

            foreach (ProductModel p in data)
            {
                p.ResetCache();
            }

            if (sort == 0)
                data = data.OrderByDescending(x => x.AvgRate).ToList();

            logger.LogInformation("Sort rate data: " + sw.ElapsedMilliseconds + " ms.");
            sw.Stop();
            sw.Restart();

            JCatalogModel catalogModel = new JCatalogModel();
            catalogModel.TotalPages = (int)MathF.Ceiling(data.Count / (float)pageCount);
            catalogModel.ProductsCount = pageCount;
            catalogModel.TotalProducts = data.Count;

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
                jdata[index].Icon = product.Pictures.First().IconSource;
                jdata[index].Url = "/catalog/" + product.Category.MetaName + "/" + product.MetaName;
                jdata[index].IsNew = product.IsNew;
                jdata[index].AvgRate = product.AvgRate;

                if (product.Discount is not null)
                {
                    jdata[index].Discount = new JDiscountModel()
                    {
                        Amount = (int)product.Discount,
                        Prise = (product.Prise - product.Prise * ((int)product.Discount / 100m)).ToString("#.##")
                    };
                }

                index++;
            }

            catalogModel.Products = jdata;
            catalogModel.CurrentPage = page;

            logger.LogInformation("Json model data: " + sw.ElapsedMilliseconds + " ms.");
            sw.Stop();
            sw.Restart();

            return Json(catalogModel);
        }
    }
}