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
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cost { get; set; }
        public string Category { get; set; }
        [JsonIgnore]
        public ImageStorageModel Main => Pictures.FirstOrDefault();
        [JsonIgnore]
        public List<ImageStorageModel> Pictures { get; set; }
        [JsonIgnore]

        public List<AttributeModel> Attributes { get; set; }
        public string Tags { get; set; }
    }
}
