using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ChipsetShop.MVC.Models
{
    [Table("Attributes")]
    public class AttributeModel
    {
        public int Id { get; set; }
        public int AttributeSceme_Id { get; set; }
        public string Value { get; set; }
        public int Product_Id { get; set; }
        [ForeignKey("AttributeSceme_Id")]
        public AttributeScemeModel AttributeSceme { get; set; }
        [ForeignKey("Product_Id")]
        public ProductModel Product { get; set; }
    }
}
