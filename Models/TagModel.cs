using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ChipsetShop.MVC.Models
{
    [Table("Tags")]
    public class TagModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Product_Id { get; set; }
        [ForeignKey("Product_Id")]
        public ProductModel Product { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
