using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace YiHe.Model.Library
{
    public class Tag
    {
        public Tag()
        {
            Used = 0;
        }

        [Key]
        public int TagId { get; set; }

        public string Name { get; set; }

        [Required]
        [DefaultValue(0)]
        public int Used { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    }
}