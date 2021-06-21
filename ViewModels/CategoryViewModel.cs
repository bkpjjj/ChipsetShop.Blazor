using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ChipsetShop.MVC.Models;
using ChipsetShop.MVC.Services;
using Microsoft.AspNetCore.Http;

namespace ChipsetShop.MVC.ViewModels
{
    public class CategoryViewModel
    {
        [MaxLength(100, ErrorMessage = "Поле имя должно быть не более 100 символов")]
        [Required(ErrorMessage = "Поле имя должно быть заполнено")]
        public string Name { get; set; }
        [MaxLength(100, ErrorMessage = "Поле ключ должно быть не более 100 символов")]

        [Required(ErrorMessage = "Поле ключ должно быть заполнено")]

        public string MetaName { get; set; }

        public IFormFile Image { get; set; }
    }
}