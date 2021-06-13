using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ChipsetShop.MVC.Models.Json
{
    public struct JRateModel
    {
        public int UserCount { get; set; }
        public int Precentage { get; set; }
    }
}