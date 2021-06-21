using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ChipsetShop.MVC.Models;
using ChipsetShop.MVC.Services;

namespace ChipsetShop.MVC.ViewModels
{
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "Пожалуйста, укажите пароль")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Пароли не совпадают")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердить пароль")]
        public string PasswordConfirm { get; set; }
    }
}