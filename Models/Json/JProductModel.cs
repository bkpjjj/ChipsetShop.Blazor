using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ChipsetShop.MVC.Models.Json
{
    public class JProductModel
    {
        public string Name { get; set; }
        public string Key { get; set; }
        public string Prise { get; set; }
        public string Category { get; set; }
        public bool IsNew { get; set; } 
        public bool InStock { get; set; }
        public float AvgRate { get; set; }
        public JDiscountModel Discount { get; set; }
        public string Icon { get; set; }
        [JsonIgnore]
        public List<string> Pictures { get; set; }
        [JsonIgnore]

        public List<AttributeModel> Attributes { get; set; }
        public string Tags { get; set; }
        public string Url { get; set; } 
    }
}
