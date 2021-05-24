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

namespace ChipsetShop.MVC.Api.Controllers
{
    [Area("api")]
    [Route("[area]/[controller]")]
    public class CatalogController : Controller
    {
        private readonly DataContext dataContext;
        public CatalogController(DataContext data)
        {
            dataContext = data;
        }

        [Route("[action]")]
        public IActionResult GetProducts(string category, string s)
        {
            dataContext.Products.Include(x => x.Tags).Include(x => x.Attributes).Include(x => x.Pictures).Include(x => x.Category).Load();
            var data = dataContext.Products.ToList();

            if(!string.IsNullOrEmpty(category) && category != "all")
                data = data.Where(x => x.Category.MetaName == category).ToList();

            if(!string.IsNullOrEmpty(s))
                data = data.Where(
                    x => x.Name.Replace(" ","").ToUpper().Contains(s.Replace(" ","").ToUpper()) ||
                         x.Tags.Any(x => x.Name.Replace(" ","").ToUpper().Contains(s.Replace(" ","").ToUpper()))
                ).ToList();

            data.Take(40);

            /*var jdata = data.Select(x => new JProductModel()
                {
                    Name = x.Name,
                    Prise = x.Prise.ToString(),
                    Tags = string.Join(" ,", x.Tags),
                    Category = x.Category.Name,
                    Icon = x.Pictures.First().IconSource,
                    Url = x.Category.MetaName + "/" + x.MetaName,
                    IsNew = x.IsNew,
                    Discount = new JDiscountModel()
                    {
                        Amount = x.Discount,
                        Prise = x.Prise * (x.Discount / 100)
                    }
                }
            );*/

            JProductModel[] jdata = new JProductModel[data.Count];
            int index = 0;
            foreach (ProductModel product in data)
            {
                jdata[index] = new JProductModel();
                jdata[index].Name = product.Name;
                jdata[index].Tags = string.Join(" ,", product.Tags);
                jdata[index].Prise = product.Prise.ToString("#.##");
                jdata[index].Category = product.Category.Name;
                jdata[index].Icon = product.Pictures.First().IconSource;
                jdata[index].Url = product.Category.MetaName + "/" + product.MetaName;
                jdata[index].IsNew = product.IsNew;

                if(product.Discount is not null)
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