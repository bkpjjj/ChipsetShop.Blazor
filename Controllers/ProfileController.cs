using ChipsetShop.MVC.ViewModels;
using ChipsetShop.MVC.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Collections.Generic;
using EmailApp;
using ChipsetShop.MVC.Models;

namespace ChipsetShop.MVC.Controllers
{
    [Authorize]
    [Route("account")]
    public class ProfileController : Controller
    {

        private readonly UserManager<UserModel> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly ViewRenderService renderService;
        private readonly SignInManager<UserModel> signInManager;
        private readonly DataContext dataContext;

        public ProfileController(ViewRenderService renderService,UserManager<UserModel> userManager, RoleManager<IdentityRole> roleManager, SignInManager<UserModel> signInManager, DataContext dataContext)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.dataContext = dataContext;
            this.roleManager = roleManager;
            this.renderService = renderService;
            dataContext.Categories.Include(x => x.Products).Load();
        }

        [Authorize]
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Comments()
        {
            ProfileCommentsViewModel vm = new ProfileCommentsViewModel();

            vm.Categories = dataContext.Categories.ToList();

            string id = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            vm.User = dataContext.Users.Find(id);
            vm.Roles = await userManager.GetRolesAsync(vm.User);

            vm.Products = dataContext.Products.Where(x => x.Comments.Any(z => z.User_Id == id));

            return View(vm);
        }

        [Authorize]
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Profile()
        {
            ProfileViewModel vm = new ProfileViewModel();

            vm.Categories = dataContext.Categories.ToList();

            string id = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            vm.User = dataContext.Users.Find(id);
            vm.Roles = await userManager.GetRolesAsync(vm.User);

            

            return View(vm);
        }
    }
}
