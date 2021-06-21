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
using System.Security.Claims;
using System.Threading.Tasks;
using EmailApp;
using System;

namespace ChipsetShop.MVC.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class CartController : Controller
    {
        private DataContext dataContext;
        private ViewRenderService renderService;

        public CartController(DataContext dataContext, ViewRenderService renderService)
        {
            this.dataContext = dataContext;
            this.renderService = renderService;
        }

        public IActionResult Index()
        {
            return View(new BaseViewModel() { Categories = dataContext.Categories.ToList() });
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Order()
        {
            Cart cart = HttpContext.Session.Get<Cart>("Cart");
            
            OrderModel order = new OrderModel();
            order.Id = Guid.NewGuid().ToString();
            order.OrderProducts = new List<OrderProductsModel>();
            order.Date = System.DateTime.Now;
            order.User_Id = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            foreach (CartLine line in cart.Lines)
            {
                var product = dataContext.Products.Find(line.Product_Id);
                OrderProductsModel p = new OrderProductsModel();
                p.Product_Id = line.Product_Id;
                p.Quontity = line.Quantity;
                order.OrderProducts.Add(p);
            }

            dataContext.Orders.Add(order);
            await dataContext.SaveChangesAsync();

            dataContext.Orders.Include(x => x.User).First(x => x.User_Id == order.User_Id);
            await EmailService.SendEmailAsync(User.FindFirst(ClaimTypes.Email).Value, $"Заказ №{order.Id}", await renderService.RenderToStringAsync("_EmailOrder", order));

            return Ok();
        }
    }
}