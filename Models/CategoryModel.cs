using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ChipsetShop.MVC.Models
{
    [Table("Categories")]
    public class CategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MetaName { get; set; }
        public string IconUrl { get; set; } 
        [NotMapped]
        public int ProductsCount => Products.Count;
        public List<ProductModel> Products { get; set; }
    }
}
