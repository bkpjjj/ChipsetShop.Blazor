using System;
using System.Collections.Generic;
using ChipsetShop.MVC.Models;
using ChipsetShop.MVC.Services;

namespace ChipsetShop.MVC.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public IEnumerable<ProductModel> NewProducts { get; set; }
        public IEnumerable<ProductModel> SaleProducts { get; set; }
    }
}