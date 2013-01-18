using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace YiHe.Model.Library
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        public string Name { get; set; }
        public virtual Category Parent { get; set; }

        public virtual ICollection<Category> Children { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
    }
}