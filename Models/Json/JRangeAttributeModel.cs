using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ChipsetShop.MVC.Models.Json
{
    public class JRangeAttributeModel : JAttributeModel
    {
        public string Min { get; set; }
    }
}