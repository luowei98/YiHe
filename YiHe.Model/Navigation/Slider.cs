using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace YiHe.Model.Navigation
{
    public class Slider
    {
        [Key]
        public int SliderId { get; set; }

        [Required]
        public int Position { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public string Link { get; set; }
    }
}
