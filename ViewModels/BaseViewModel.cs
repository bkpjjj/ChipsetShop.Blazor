using System;
using System.Collections.Generic;
using System.Linq;
using ChipsetShop.MVC.Models;
using ChipsetShop.MVC.Services;
using Microsoft.EntityFrameworkCore;

namespace ChipsetShop.MVC.ViewModels
{
    public class BaseViewModel
    {
        public IEnumerable<CategoryModel> Categories  {get; set; }
    }    
}