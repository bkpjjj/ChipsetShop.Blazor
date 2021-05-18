using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ChipsetShop.MVC.Models
{
    [Table("ImageStorage")]
    public class ImageStorageModel
    {
        public int Id { get; set; }
        public string ImageSource { get; set; }
        public string IconSource { get; set; }
        public int Product_Id { get; set; }
        [ForeignKey("Product_Id")]
        public ProductModel Product { get; set; }
    }
}
