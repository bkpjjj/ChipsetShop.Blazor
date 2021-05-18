using Microsoft.AspNetCore.Mvc;

namespace ChipsetShop.MVC.Controllers
{
    [Route("[controller]")]
    public class CatalogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}