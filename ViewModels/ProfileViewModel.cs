using System;
using System.Collections.Generic;
using ChipsetShop.MVC.Models;
using ChipsetShop.MVC.Services;
using Microsoft.AspNetCore.Identity;

namespace ChipsetShop.MVC.ViewModels
{
    public class ProfileViewModel : BaseViewModel
    {
        public UserModel User { get; set; }
        public IList<string> Roles { get; set; }

        public ChangePasswordViewModel ChangePassword { get; set; } = new ChangePasswordViewModel();

        public PersonalDataViewModel PersonalData { get; set; } = new PersonalDataViewModel();
    }
}