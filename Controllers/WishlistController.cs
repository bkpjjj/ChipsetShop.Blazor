using System.Linq;
using ChipsetShop.MVC.Services;
using ChipsetShop.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using System.Collections.Generic;
using ChipsetShop.MVC.Models;

namespace ChipsetShop.MVC.Controllers
{
    [Route("[controller]")]
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

            IEnumerable<ProductModel> products =  dataContext.Products.Where(x => wishlistMetanames.Any(n => n == x.MetaName));

            return View(new WishlistViewModel() { Categories = dataContext.Categories.ToList(), Products =products });
        }
    }
}