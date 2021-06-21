using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ChipsetShop.MVC.Models
{
    [Table("Orders")]
    public class OrderModel
    {
        [Key]
        public string Id { get; set; }
        [ForeignKey("User_Id")]
        public UserModel User { get; set; }
        public string User_Id { get; set; }
        public DateTime Date { get; set; }

        public List<OrderProductsModel> OrderProducts { get; set; }
    }
}
