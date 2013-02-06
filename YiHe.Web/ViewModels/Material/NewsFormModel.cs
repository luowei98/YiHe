using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using YiHe.Web.Helpers;


namespace YiHe.Web.ViewModels.Material
{
    public class NewsFormModel
    {
        public NewsFormModel()
        {
            CreateTime = DateTime.Now.ToString("yyyy-M-d");
            Picture = "news.png";
        }

        public int NewsId { get; set; }

        [Required(ErrorMessage = "请输入标题。")]
        [DisplayName("标题")]
        public string Title { get; set; }

        [DisplayName("图片")]
        public string Picture { get; set; }

        [Required(ErrorMessage = "请输入内容。")]
        [DisplayName("内容")]
        public string Content { get; set; }

        [Required(ErrorMessage = "请输入时间。")]
        [DisplayName("时间")]
        [RegularExpression(RegularHelper.DATE, ErrorMessage = "请输入正确的时间格式。")]
        public string CreateTime { get; set; }
    }
}