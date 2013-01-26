using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;


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


        public bool IsRoot
        {
            get { return Parent == null; }
        }

        public IEnumerable<Category> Chain
        {
            get
            {
                for (var category = this; category != null; category = category.Parent)
                {
                    yield return category;
                }
            }
        }

        public Category RootParent
        {
            get
            {
                return Chain.Last();
            }
        }
    }
}