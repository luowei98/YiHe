using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace YiHe.Model.Navigation
{
    public class Menu
    {
        public Menu()
        {
            Role = 0;
        }

        [Key]
        public int MenuId { get; set; }

        public virtual Menu Parent { get; set; }

        [Required]
        public string MenuText { get; set; }

        [Required]
        public int Position { get; set; }

        [Required]
        public string UrlController { get; set; }

        [Required]
        public string UrlAction { get; set; }

        public string BackgroundImage { get; set; }

        [DefaultValue(10)]
        public int Role { get; set; }

        public virtual ICollection<Menu> Children { get; set; }
    }
}