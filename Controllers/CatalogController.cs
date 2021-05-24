using System.Linq;
using ChipsetShop.MVC.Services;
using ChipsetShop.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChipsetShop.MVC.Controllers
{
    [Route("[controller]")]
    public class CatalogController : Controller
    {
        private readonly DataContext dataContext;
        public CatalogController(DataContext data)
        {
            dataContext = data;
        }

        [Route("{category}")]
        public IActionResult Index(string category)
        {
            dataContext.Categories.Include(x => x.Products).Load();

            var model = new BaseViewModel()
            {
                Categories = dataContext.Categories.ToList(),
            };

            if(dataContext.Categories.Any(x => x.MetaName == category) || category == "all")
                return View(model);

            return NotFound();
        }

        [Route("{category}/{metaname}")]
        public IActionResult Product(string category, string metaname)
        {
            dataContext.Attributes.Include(x => x.AttributeSceme).Include(x => x.Product).Load();
            dataContext.Products.Include(x => x.Tags).Include(x => x.Attributes).Include(x => x.Pictures).Include(x => x.Category).Load();

            var product = dataContext.Products.Where(x => x.MetaName == metaname).FirstOrDefault();

            var model = new ProductViewModel()
            {
                Categories = dataContext.Categories.ToList(),
                Product = product
            };

            if(product is not null)
                return View(model);

            return NotFound();
        }
    }
}