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
    public class CatalogController : Controller
    {
        private readonly DataContext dataContext;
        public CatalogController(DataContext data)
        {
            dataContext = data;
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
                    if(!attributePoll.Contains(a.AttributeSceme))
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
        public IActionResult Products(string category, string s, int page,[FromQuery(Name = "filters[]")]string[] filters, int pageCount = 18)
        {
            dataContext.Products.Include(x => x.Tags).Include(x => x.Attributes).Include(x => x.Pictures).Include(x => x.Category).Load();
            var data = dataContext.Products.ToList();

            if (!string.IsNullOrEmpty(category) && category != "all")
                data = data.Where(x => x.Category.MetaName == category).ToList();

            if (filters.Length > 0)
                data = data.Where(x => filters.Any(f => x.Attributes.Any(a => a.Value == f))).ToList();

            if (!string.IsNullOrEmpty(s))
                data = data.Where(
                    x => x.Name.Replace(" ", "").ToUpper().Contains(s.Replace(" ", "").ToUpper()) ||
                         x.Tags.Any(x => x.Name.Replace(" ", "").ToUpper().Contains(s.Replace(" ", "").ToUpper()))
                ).ToList();

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

            return Json(catalogModel);
        }
    }
}