using System.ComponentModel.DataAnnotations;


namespace YiHe.Model.Navigation
{
    public class OuterLink
    {

        [Key]
        public int OuterLinkId { get; set; }

        [Required]
        public int Position { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public string Url { get; set; }
    }
}