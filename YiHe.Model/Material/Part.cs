using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace YiHe.Model.Material
{
    public class Part
    {
        [Key]
        public int PartId { get; set; }

        [Required]
        public int MenuId { get; set; }

        [Required]
        public string Title { get; set; }

        public string IconPath { get; set; }

        public string MetaDescription { get; set; }

        public string MetaKeywords { get; set; }

        public virtual ICollection<Element> Elements { get; set; }
    }
}