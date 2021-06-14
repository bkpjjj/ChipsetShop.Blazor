using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ChipsetShop.MVC.Models
{
    [Table("Comments")]
    public class CommentModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        [MaxLength(60)]
        public string Title { get; set; }
        public string Dignity { get; set; }
        public string Limitations { get; set; }
        public DateTime Date { get; set; }
        public int Rate { get; set; }
        public int Product_Id { get; set; }
        [ForeignKey("Product_Id")]
        public ProductModel Product { get; set; }
        public string User_Id { get; set; }
        [ForeignKey("User_Id")]
        public IdentityUser User { get; set; }
    }
}
