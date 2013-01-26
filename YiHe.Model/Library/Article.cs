using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;


namespace YiHe.Model.Library
{
    public class Article
    {
        public Article()
        {
            CreateTime = DateTime.Now;
            BrowseTimes = 0;
            //Tags = new HashSet<Tag>();
        }

        [Key]
        public int ArticleId { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public string Title { get; set; }
        public string Author { get; set; }
        public string ExtractFrom { get; set; }
        public string Picture { get; set; }
        public string Content { get; set; }

        [Required]
        public DateTime CreateTime { get; set; }

        [Required]
        [DefaultValue(0)]
        public int BrowseTimes { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }

        public IEnumerable<Tag> TripTags
        {
            get
            {
                return Tags
                    .OrderByDescending(t => t.Used)
                    .Take(3);
            }
        }
    }
}