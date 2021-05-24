using System;
using System.Collections.Generic;
using ChipsetShop.MVC.Models;
using ChipsetShop.MVC.Services;

namespace ChipsetShop.MVC.ViewModels
{
    public class ProductViewModel : BaseViewModel
    {
        public ProductModel Product { get; set; }
    }
}