using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ChipsetShop.MVC.Models;
using Microsoft.AspNetCore.Identity;

namespace ChipsetShop.MVC.Services
{
    public class CustomPasswordValidator : PasswordValidator<UserModel>
    {
        const int RequiredLength = 6;
        const int MaxRequiredLength = 16;
        public override async Task<IdentityResult> ValidateAsync(UserManager<UserModel> manager, UserModel user, string password)
        {
            List<IdentityError> errors = new List<IdentityError>();

            if (String.IsNullOrEmpty(password) || password.Length < RequiredLength)
            {
                errors.Add(new IdentityError
                {
                    Description = $"Минимальная длина пароля равна {RequiredLength} символов"
                });
            }

            if (password.Length > MaxRequiredLength)
            {
                errors.Add(new IdentityError
                {
                    Description = $"Максимальная длина пароля равна {MaxRequiredLength} символа"
                });
            }

            string pattern = "[0-9]";
 
            if (Regex.Matches(password, pattern).Count < 2)
            {
                errors.Add(new IdentityError
                {
                    Description = "Пароль должен содержать хотя бы две цифры"
                });
            }

            return await Task.FromResult(errors.Count == 0 ? IdentityResult.Success : IdentityResult.Failed(errors.ToArray()));
        }
    }
}