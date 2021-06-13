using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ChipsetShop.MVC.Models.Json
{
    public class JUserModel
    {
        public string Login { get; set; }
        public string Email { get; set; }
    }
}