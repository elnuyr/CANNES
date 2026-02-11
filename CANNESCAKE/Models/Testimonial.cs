using System.ComponentModel.DataAnnotations;

namespace CANNESCAKE.Models
{
    public class Testimonial : BaseEntity
    {

        [Required(ErrorMessage = "Müştəri adı daxil edilməlidir")]
        [StringLength(100)]
        public string ClientName { get; set; } = string.Empty;

        [StringLength(100)]
        public string? Profession { get; set; }

        [Required(ErrorMessage = "Rəy daxil edilməlidir")]
        [StringLength(1000)]
        public string Comment { get; set; } = string.Empty;

        [StringLength(500)]
        public string? ImageUrl { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; } = 5;

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public bool IsApproved { get; set; } = false;
    }
}
