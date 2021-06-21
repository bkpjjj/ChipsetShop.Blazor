using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ChipsetShop.MVC.Models
{
    [Table("OrderProducts")]
    public class OrderProductsModel
    {
        [Key]
        public int Id { get; set; }
        public string Order_Id { get; set; }
        [ForeignKey("Order_Id")]
        public OrderModel Order { get; set; }
        public int Product_Id { get; set; }
        [ForeignKey("Product_Id")]
        public ProductModel Product { get; set; }
        public int Quontity { get; set; }
    }
}
