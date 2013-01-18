using System.ComponentModel.DataAnnotations;


namespace YiHe.Model.Material
{
    public class OfficePhotoDetail
    {
        [Key]
        public int OfficePhotoDetailId { get; set; }

        public string DetailPhoto { get; set; }
    }
}