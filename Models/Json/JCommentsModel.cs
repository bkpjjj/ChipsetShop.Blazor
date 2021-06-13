using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ChipsetShop.MVC.Models.Json
{
    public class JCommentsModel
    {
        public IEnumerable<JCommentModel> Comments { get; set; }
        public IEnumerable<JRateModel> TotalRateDetail { get; set; }
        public float TotalRate { get; set; }
        public int CommentsCount { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
    }
}