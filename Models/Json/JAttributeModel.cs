using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ChipsetShop.MVC.Models.Json
{
    public class JAttributeModel
    {
        public string Name { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public FieldType FieldType { get; set; }
        public bool IsGeneral { get; set; }

    }
}