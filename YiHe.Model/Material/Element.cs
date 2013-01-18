using System.ComponentModel.DataAnnotations;


namespace YiHe.Model.Material
{
    public class Element
    {
        [Key]
        public int ElementId { get; set; }

        [Required]
        public int No { get; set; }

        public string Title { get; set; }

        public string Detail { get; set; }

        public string SubDetail { get; set; }
    }
}