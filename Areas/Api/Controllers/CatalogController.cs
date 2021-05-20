using System.Linq;
using ChipsetShop.MVC.Models.Json;
using ChipsetShop.MVC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public IActionResult GetProducts(string category)
        {
            dataContext.Products.Include(x => x.Tags).Include(x => x.Attributes).Include(x => x.Pictures).Include(x => x.Category).Load();
            var data = dataContext.Products.ToList().Select(x => new JProductModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Cost = x.Cost.ToString("#.## руб\\."),
                    Tags = string.Join(" ,", x.Tags),
                    Category = x.Category.Name
                }
            );

            return Json(data);
        }
    }
}