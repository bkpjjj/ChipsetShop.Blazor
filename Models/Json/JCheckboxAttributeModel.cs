using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ChipsetShop.MVC.Models.Json
{
    public struct JCheckboxValue
    {
        public string Value { get; set; }
        public int Count { get; set; }
    }
    public class JCheckboxAttributeModel : JAttributeModel
    {
        public IEnumerable<JCheckboxValue> Values { get; set; }
    }
}