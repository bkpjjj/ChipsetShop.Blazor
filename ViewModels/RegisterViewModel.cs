using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ChipsetShop.MVC.Models;
using ChipsetShop.MVC.Services;

namespace ChipsetShop.MVC.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        [Required(ErrorMessage = "Пожалуйста, укажите логин")]
        [Display(Name = "Логин")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Пожалуйста, укажите адрес почты")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Пожалуйста, укажите пароль")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Пароли не совпадают")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердить пароль")]
        public string PasswordConfirm { get; set; }

        //Personal Data

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Поле должно быть заполнено")]

        public string LastName { get; set; }
        [Required(ErrorMessage = "Поле должно быть заполнено")]

        public string Address { get; set; }
        [Required(ErrorMessage = "Поле должно быть заполнено")]

        public string City { get; set; }
        [Required(ErrorMessage = "Поле должно быть заполнено")]

        public string Country { get; set; }
        [Required(ErrorMessage = "Поле должно быть заполнено")]

        public int ZIPCode { get; set; }
        [Required(ErrorMessage = "Поле должно быть заполнено")]

        public string Telephone { get; set; }
    }
}