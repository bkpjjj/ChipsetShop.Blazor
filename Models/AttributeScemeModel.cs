using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ChipsetShop.MVC.Models
{
    [Table("AttributeScemes")]
    public class AttributeScemeModel
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public bool IsGeneral { get; set; }
        public List<AttributeModel> Attributes { get; set; }
    }
}
