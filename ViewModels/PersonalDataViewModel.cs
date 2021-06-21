using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ChipsetShop.MVC.Models;
using ChipsetShop.MVC.Services;

namespace ChipsetShop.MVC.ViewModels
{
    public class PersonalDataViewModel
    {
        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [Display(Name = "Адрес")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [Display(Name = "Город")]
        public string City { get; set; }
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [Display(Name = "Страна")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [Display(Name = "Почтовый индекс")]
        public int ZIPCode { get; set; }
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [Display(Name = "Телефон")]
        public string Telephone { get; set; }
    }
}