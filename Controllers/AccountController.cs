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
    [Route("[controller]")]
    public class AccountController : Controller
    {

        private readonly UserManager<UserModel> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly ViewRenderService renderService;
        private readonly SignInManager<UserModel> signInManager;
        private readonly DataContext dataContext;

        public AccountController(ViewRenderService renderService, UserManager<UserModel> userManager, RoleManager<IdentityRole> roleManager, SignInManager<UserModel> signInManager, DataContext dataContext)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.dataContext = dataContext;
            this.roleManager = roleManager;
            this.renderService = renderService;
            dataContext.Categories.Include(x => x.Products).Load();
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult Login()
        {
            if (User.Identity is not null)
                if (User.Identity.IsAuthenticated)
                    return Redirect("/");

            return View(new LoginViewModel() { Categories = dataContext.Categories.ToList() });
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult Register()
        {
            return View(new RegisterViewModel() { Categories = dataContext.Categories.ToList() });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("[action]")]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            model.Categories = dataContext.Categories.ToList();

            if (ModelState.IsValid)
            {
                UserModel user = new UserModel
                {
                    Email = model.Email,
                    NormalizedEmail = model.Email.ToUpper(),
                    UserName = model.UserName,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Address = model.Address,
                    City = model.City,
                    Country = model.Country,
                    ZIPCode = model.ZIPCode,
                    Telephone = model.Telephone
                };
                // добавляем пользователя
                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "user");
                    await dataContext.SaveChangesAsync();
                    var code = await userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.Action(
                        "ConfirmEmail",
                        "Account",
                        new { userId = user.Id, code = code },
                        protocol: HttpContext.Request.Scheme);
                    await EmailService.SendEmailAsync(model.Email, "Подтвердите регистрацию",
                       await renderService.RenderToStringAsync("_EmailConfirm", callbackUrl));


                    return View("_Confirm", new BaseViewModel() { Categories = dataContext.Categories.ToList() });
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
        [Route("[action]")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            model.Categories = dataContext.Categories.ToList();

            if (ModelState.IsValid)
            {
                var result =
                    await signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    var user = await userManager.FindByNameAsync(model.UserName);
                    if (user != null)
                    {
                        // проверяем, подтвержден ли email
                        if (!await userManager.IsEmailConfirmedAsync(user))
                        {
                            ModelState.AddModelError(string.Empty, "Вы не подтвердили свой email");
                            return View(model);
                        }
                    }
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
                if (result.IsLockedOut)
                {
                    ModelState.AddModelError("", "Ваш профиль заблокирован");
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
        [Route("[action]")]
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

        [HttpGet]
        [AllowAnonymous]
        [Route("[action]")]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return BadRequest("Error");
            }
            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return BadRequest("Error");
            }
            var result = await userManager.ConfirmEmailAsync(user, code);
            await dataContext.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            List<string> errors = new List<string>();
            if (ModelState.IsValid)
            {
                UserModel user = await userManager.FindByIdAsync(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                if (user != null)
                {
                    var _passwordValidator =
                        HttpContext.RequestServices.GetService(typeof(IPasswordValidator<UserModel>)) as IPasswordValidator<UserModel>;
                    var _passwordHasher =
                        HttpContext.RequestServices.GetService(typeof(IPasswordHasher<UserModel>)) as IPasswordHasher<UserModel>;

                    IdentityResult result =
                        await _passwordValidator.ValidateAsync(userManager, user, model.Password);
                    if (result.Succeeded)
                    {
                        user.PasswordHash = _passwordHasher.HashPassword(user, model.Password);
                        await userManager.UpdateAsync(user);
                        await dataContext.SaveChangesAsync();
                        return Ok("[\"Изменено!\"]");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            errors.Add(error.Description);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Пользователь не найден");
                }
            }

            return BadRequest(errors);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        [Route("[action]")]
        public async Task<IActionResult> ChangePersonalData(PersonalDataViewModel model)
        {
            if (ModelState.IsValid)
            {
                UserModel user = await userManager.FindByIdAsync(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                if (user != null)
                {
                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;
                    user.Address = model.Address;
                    user.City = model.City;
                    user.Country = model.Country;
                    user.ZIPCode = model.ZIPCode;
                    user.Telephone = model.Telephone;
                    await userManager.UpdateAsync(user);
                    await dataContext.SaveChangesAsync();
                    return Ok("[\"Изменено!\"]");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Пользователь не найден");
                }
            }

            return BadRequest("[\"Ошибка повторите попытку позже!\"]");
        }
    }
}
