using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace YiHe.Model.Material
{
    public class OfficePhoto
    {
        [Key]
        public int OfficePhotoId { get; set; }

        public string Name { get; set; }

        public int Position { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string MainPhoto { get; set; }

        public string SmallerPhoto { get; set; }


        public virtual ICollection<OfficePhotoDetail> Details { get; set; }
    }
}
