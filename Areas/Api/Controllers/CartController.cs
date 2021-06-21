using System.Linq;
using ChipsetShop.MVC.Services;
using ChipsetShop.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using ChipsetShop.MVC.Models;
using System.Collections.Generic;
using ChipsetShop.MVC.Models.Json;

namespace ChipsetShop.MVC.Api.Controllers
{
    [ApiController]
    [Area("api")]
    [Route("[area]/[controller]")]
    public class CartController : Controller
    {
        private DataContext dataContext;

        public CartController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public IActionResult Cart()
        {
            List<JLineModel> lines = new List<JLineModel>();
            decimal totalPrise = 0;
            foreach (var cartLine in GetCart().Lines)
            {
                var line = new JLineModel()
                {
                    Quontity = cartLine.Quantity
                };

                var product = dataContext.Products.Include(x => x.Tags).Include(x => x.Comments).Include(x => x.Attributes).Include(x => x.Pictures).Include(x => x.Category).First(x => x.Id == cartLine.Product_Id);
                line.Product = new JProductModel();
                line.Product.Name = product.Name;
                line.Product.Key = product.MetaName;
                line.Product.Tags = string.Join(" ,", product.Tags);
                line.Product.Prise = product.Prise.ToString("#.##");
                line.Product.InStock = product.InStock;
                line.Product.Category = product.Category.Name;
                line.Product.Icon = product.Pictures.First().ImageSource;
                line.Product.Url = "/catalog/" + product.Category.MetaName + "/" + product.MetaName;
                line.Product.IsNew = product.IsNew;
                line.Product.AvgRate = product.AvgRate;

                if (product.Discount > 0)
                {
                    line.Product.Discount = new JDiscountModel()
                    {
                        Amount = (int)product.Discount,
                        Prise = product.DicountPrise.ToString("#.##")
                    };

                    totalPrise += product.DicountPrise * cartLine.Quantity;
                }
                else
                {
                    totalPrise += product.Prise * cartLine.Quantity;
                }

                lines.Add(line);
            }


            return Json(new { Cart = lines, TotalPrise = totalPrise.ToString("#.##") });
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult AddOne([FromForm] string metaname)
        {
            ProductModel product = dataContext.Products.FirstOrDefault(x => x.MetaName == metaname);

            if (product != null)
            {
                var cart = GetCart();
                cart.AddItem(product, 1);
                SaveCart(cart);
            }
            return Ok();
        }
        [HttpPost]
        [Route("[action]")]
        public IActionResult Add([FromForm] string metaname, [FromForm] int qountity)
        {
            ProductModel product = dataContext.Products.FirstOrDefault(x => x.MetaName == metaname);

            if (product != null)
            {
                var cart = GetCart();
                cart.AddItem(product, qountity);
                SaveCart(cart);
            }
            return Ok();
        }
        [HttpPost]
        [Route("[action]")]
        public IActionResult Remove([FromForm] string metaname)
        {
            ProductModel product = dataContext.Products.FirstOrDefault(x => x.MetaName == metaname);

            if (product != null)
            {
                var cart = GetCart();
                cart.RemoveLine(product);
                SaveCart(cart);
            }
            return Ok();
        }
        private Cart GetCart()
        {
            Cart cart = HttpContext.Session.Get<Cart>("Cart");
            if (cart == null)
            {
                cart = new Cart();
                HttpContext.Session.Set("Cart", cart);
            }
            return cart;
        }

        private void SaveCart(Cart cart)
        {
            HttpContext.Session.Set("Cart", cart);
        }
    }
}