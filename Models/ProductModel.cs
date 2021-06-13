using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ChipsetShop.MVC.Models
{
    [Table("Products")]
    public class ProductModel
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string MetaName { get; set; }
        public decimal Prise { get; set; }
        public bool IsNew { get; set; } 
        public int? Discount { get; set; }
        public bool InStock { get; set; }
        public int Category_Id { get; set; }
        [ForeignKey("Category_Id")]
        public CategoryModel Category { get; set; }
        [NotMapped]
        public ImageStorageModel Main => Pictures.FirstOrDefault();
        public List<ImageStorageModel> Pictures { get; set; }
        public List<AttributeModel> Attributes { get; set; }
        public List<TagModel> Tags { get; set; }
        public List<CommentModel> Comments { get; set; }
        [NotMapped]
        public float AvgRate => _avgRate ?? CalcAvgRate();
        private float? _avgRate = null;
        private float CalcAvgRate()
        {
            _avgRate = Comments.Count <= 0 ? 0 : MathF.Round(Comments.Average(x => (float)x.Rate), 2);
            return (float)_avgRate;
        }

        public void ResetCache()
        {
            _avgRate = null;
        }
    }
}
