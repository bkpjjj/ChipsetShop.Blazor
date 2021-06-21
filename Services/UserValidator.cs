using System.Collections.Generic;
using System.Threading.Tasks;
using ChipsetShop.MVC.Models;
using Microsoft.AspNetCore.Identity;

namespace ChipsetShop.MVC.Services
{
    class CustomUserValidator : UserValidator<UserModel>
    {
        public override async Task<IdentityResult> ValidateAsync(UserManager<UserModel> manager, UserModel user)
        {
            List<IdentityError> errors = new List<IdentityError>();

            var fuser = await manager.FindByNameAsync(user.UserName);
            if(fuser is not null)
            {
                errors.Add(new IdentityError
                {
                    Description = $"Пользватель с именем {user.UserName} уже существует.",
                });
            }

            fuser = await manager.FindByEmailAsync(user.NormalizedEmail);
            if(fuser is not null)
            {
                errors.Add(new IdentityError
                {
                    Description = $"Пользватель с такой почтой уже существует.",
                });
            }

            return await Task.FromResult(errors.Count == 0 ? IdentityResult.Success : IdentityResult.Failed(errors.ToArray()));
        }
    }
}