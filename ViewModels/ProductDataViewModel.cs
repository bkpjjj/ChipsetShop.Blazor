using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ChipsetShop.MVC.Models;
using ChipsetShop.MVC.Services;
using Microsoft.AspNetCore.Http;

namespace ChipsetShop.MVC.ViewModels
{

    public class AttributeDataViewModel
    {
        [Required(ErrorMessage = "Поле имя аттрибута должно быть заполнено")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Поле значеие аттрибута должно быть заполнено")]
        public string Value { get; set; }
        public bool IsGeneral { get; set; }
    }
    public class ProductDataViewModel
    {
        public int Id { get; set; }
        [MaxLength(100, ErrorMessage = "Поле имя должно быть не более 100 символов")]
        [Required(ErrorMessage = "Поле имя должно быть заполнено")]
        public string Name { get; set; }
        [MaxLength(100, ErrorMessage = "Поле ключ должно быть не более 100 символов")]

        [Required(ErrorMessage = "Поле ключ должно быть заполнено")]

        public string MetaName { get; set; }
        [Required(ErrorMessage = "Поле цена должно быть заполнено")]

        public decimal Prise { get; set; }
        [Required(ErrorMessage = "Поле новинка должно быть заполнено")]

        public bool IsNew { get; set; }
        [Required(ErrorMessage = "Поле в скидка должно быть заполнено")]

        public int Discount { get; set; }
        [Required(ErrorMessage = "Поле количество должно быть заполнено")]

        public int Quontity { get; set; }
        [Required(ErrorMessage = "Поле в наличии должно быть заполнено")]

        public bool InStock { get; set; }
        [Required(ErrorMessage = "Поле категория должно быть заполнено")]

        public string Category { get; set; }

        public string Tags { get; set; }

        public IEnumerable<AttributeDataViewModel> Attributes { get; set; }

        public IEnumerable<IFormFile> Images { get; set; }
    }
}