using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace YiHe.Web.Models.Library
{
    public class ArticleModel
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }

        [DisplayName("作者: ")]
        public string Author { get; set; }

        [DisplayName("出自: ")]
        public string ExtractFrom { get; set; }

        public string PicturePath { get; set; }
        public string Content { get; set; }

        [DisplayName("上传时间: ")]
        [DisplayFormat(DataFormatString = "{0:yyyy年M月d日}")]
        public DateTime CreateTime { get; set; }

        [DisplayName("被围观次数: ")]
        public int BrowseTimes { get; set; }

        public string  CategoryName { get; set; }
    }
}