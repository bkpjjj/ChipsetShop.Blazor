using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ChipsetShop.MVC.Models.Json
{
    public class JAdminCatalogModel
    {
        public IEnumerable<JAdminProductModel> Products { get; set; }
        public IEnumerable<JCategoryModel> Categories { get; set; }
        public int TotalProducts { get; set; }
        public int ProductsCount { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }

        public decimal MinPrise { get; set; } 
        public decimal MaxPrise { get; set; } 
    }
}
