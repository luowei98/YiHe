using System;
using System.ComponentModel.DataAnnotations;


namespace YiHe.Model.Material
{
    public class Staff
    {
        [Key]
        public int StaffId { get; set; }

        [Required]
        public int Position { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime Birthday { get; set; }

        public string Qualification { get; set; }

        public string Therapy { get; set; }

        public string Skill { get; set; }

        public string Introduction { get; set; }

        public string Photo { get; set; }
    }
}