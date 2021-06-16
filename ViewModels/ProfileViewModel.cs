using System;
using System.Collections.Generic;
using ChipsetShop.MVC.Models;
using ChipsetShop.MVC.Services;
using Microsoft.AspNetCore.Identity;

namespace ChipsetShop.MVC.ViewModels
{
    public class ProfileViewModel : BaseViewModel
    {
        public IdentityUser User { get; set; }
        public IList<string> Roles { get; set; }
    }
}