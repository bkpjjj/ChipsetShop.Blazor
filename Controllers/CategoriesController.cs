using System.Linq;
using ChipsetShop.MVC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChipsetShop.MVC.Controllers
{
    [Route("[controller]")]
    public class CategoriesController : Controller
    {
        private readonly DataContext _context;

        public CategoriesController(DataContext context)
        {
            _context = context;

            _context.Categories.Include(i => i.Products).Load();
        }

        public IActionResult Index()
        {
            return View(_context.Categories.ToList());
        }
    }
}