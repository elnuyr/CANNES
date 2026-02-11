using System.ComponentModel.DataAnnotations;

namespace CANNESCAKE.Models
{
    public class ContactMessage : BaseEntity
    {
        
        [Required(ErrorMessage = "Adınızı daxil edin")]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "E-poçt daxil edin")]
        [EmailAddress(ErrorMessage = "Düzgün e-poçt ünvanı daxil edin")]
        [StringLength(200)]
        public string Email { get; set; } = string.Empty;

        [StringLength(200)]
        public string? Subject { get; set; }

        [Required(ErrorMessage = "Mesajınızı daxil edin")]
        [StringLength(2000)]
        public string Message { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public bool IsRead { get; set; } = false;
    }
}
