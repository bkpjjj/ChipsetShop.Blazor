using System;
using System.Collections.Generic;
using ChipsetShop.MVC.Models;
using ChipsetShop.MVC.Services;
using Microsoft.AspNetCore.Identity;

namespace ChipsetShop.MVC.ViewModels
{
    public class ProfileCommentsViewModel : BaseViewModel
    {
        public UserModel User { get; set; }
        public IList<string> Roles { get; set; }

        public IEnumerable<ProductModel> Products { get; set; }
    }
}