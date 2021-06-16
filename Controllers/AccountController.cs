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

namespace ChipsetShop.MVC.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly DataContext dataContext;

        public AccountController(UserManager<IdentityUser> userManager,RoleManager<IdentityRole> roleManager, SignInManager<IdentityUser> signInManager, DataContext dataContext)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.dataContext = dataContext;
            this.roleManager = roleManager;
            dataContext.Categories.Include(x => x.Products).Load();
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity is not null)
                if (User.Identity.IsAuthenticated)
                    return Redirect("/");

            return View(new LoginViewModel() { Categories = dataContext.Categories.ToList() });
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View(new RegisterViewModel() { Categories = dataContext.Categories.ToList() });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            model.Categories = dataContext.Categories.ToList();

            if (ModelState.IsValid)
            {
                IdentityUser user = new IdentityUser { Email = model.Email, UserName = model.UserName };
                // добавляем пользователя
                var result = await userManager.CreateAsync(user, model.Password);
               
                if (result.Succeeded)
                {
                     await userManager.AddToRoleAsync(user, "user");
                    await signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            model.Categories = dataContext.Categories.ToList();

            if (ModelState.IsValid)
            {
                var result =
                    await signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    // проверяем, принадлежит ли URL приложению
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный логин и (или) пароль");
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout(string returnUrl)
        {
            // удаляем аутентификационные куки
            await signInManager.SignOutAsync();

            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            ProfileViewModel vm = new ProfileViewModel();

            vm.Categories = dataContext.Categories.ToList();

            string id = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            vm.User = dataContext.Users.Find(id);
            vm.Roles = await userManager.GetRolesAsync(vm.User);

            return View(vm);
        }

        [HttpPatch]
        public IActionResult GetProductPartial()
        {
            return PartialView(new BaseViewModel() { Categories = dataContext.Categories.ToList() });
        }
    }
}
