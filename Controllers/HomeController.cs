using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ChipsetShop.MVC.Models;
using ChipsetShop.MVC.ViewModels;
using ChipsetShop.MVC.Services;
using Microsoft.EntityFrameworkCore;

namespace ChipsetShop.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext dataContext;

        public HomeController(DataContext data)
        {
            dataContext = data;
        }

        public IActionResult Index()
        {
            dataContext.Attributes.Include(x => x.AttributeSceme).Load();
            dataContext.Products.Include(x => x.Tags).Include(x => x.Attributes).Include(x => x.Pictures).Include(x => x.Category).Load();

            var model = new HomeViewModel()
            {
                Categories = dataContext.Categories.ToList(),
                NewProducts = dataContext.Products.OrderBy(x => x.Id).Where(x => x.IsNew && x.InStock).AsEnumerable().TakeLast(4),
                SaleProducts = dataContext.Products.OrderBy(x => x.Id).Where(x => x.Discount > 0 && x.InStock).AsEnumerable().TakeLast(4)
            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View(new BaseViewModel() { Categories = dataContext.Categories.ToList() });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
