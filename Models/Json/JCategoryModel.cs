using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ChipsetShop.MVC.Models.Json
{
    public class JCategoryModel
    {
        public string Key { get; set; }
        public string Name { get; set; }
    }
}
