using System;
using System.Collections.Generic;
using ChipsetShop.MVC.Models;
using ChipsetShop.MVC.Services;

namespace ChipsetShop.MVC.ViewModels
{
    public class WishlistViewModel : BaseViewModel
    {
        public IEnumerable<ProductModel> Products { get; set; }
    }
}