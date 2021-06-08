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

namespace ChipsetShop.MVC.Api.Controllers
{
    [ApiController]
    [Area("api")]
    [Route("[area]/[controller]")]
    public class WishlistController : Controller
    {
        private readonly DataContext dataContext;
        public WishlistController(DataContext data)
        {
            dataContext = data;
        }

        public IActionResult Index()
        {
            dataContext.Attributes.Include(x => x.AttributeSceme).Include(x => x.Product).Load();
            dataContext.Products.Include(x => x.Tags).Include(x => x.Attributes).Include(x => x.Pictures).Include(x => x.Category).Load();

            string[] wishlistMetanames = new string[0];
            if(HttpContext.Request.Cookies.ContainsKey("wishlist"))
                wishlistMetanames = Request.Cookies["wishlist"].Split(",");

            List<ProductModel> products =  dataContext.Products.Where(x => wishlistMetanames.Any(n => n == x.MetaName)).ToList();

            JProductModel[] jdata = new JProductModel[products.Count];
            int index = 0;
            foreach (ProductModel product in products)
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

            return Json(jdata);
        }
    }
}