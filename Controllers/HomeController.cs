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
            dataContext.Categories.Include(x => x.Products).Load();

            var model = new HomeViewModel()
            {
                Categories = dataContext.Categories.ToList(),
            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
