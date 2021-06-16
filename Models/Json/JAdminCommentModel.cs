using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ChipsetShop.MVC.Models.Json
{
    public class JAdminCommentModel
    {
        public int Id { get; set; }
        public class JAdminProductModel
        {
            public string Key { get; set; } 
            public string Url { get; set; } 
        }

        public string Text { get; set; }
        public string Title { get; set; }
        public string Dignity { get; set; }
        public string Limitations { get; set; }
        public string Date { get; set; }
        public int Rate { get; set; }
        public JUserModel User { get; set; }
        public JAdminProductModel Product { get; set; }
    }
}