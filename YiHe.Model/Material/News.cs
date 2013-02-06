using System;
using System.ComponentModel.DataAnnotations;


namespace YiHe.Model.Material
{
    public class News
    {
        [Key]
        public int NewsId { get; set; }

        public string Title { get; set; }
        public string Picture { get; set; }
        public string Content { get; set; }

        [Required]
        public DateTime CreateTime { get; set; }
    }
}