using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ChipsetShop.MVC.Models.Json
{
    public class JAdminCommentsModel
    {
        public IEnumerable<JAdminCommentModel> Comments { get; set; }
        public int CommentsCount { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
    }
}