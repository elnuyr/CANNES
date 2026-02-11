using System.ComponentModel.DataAnnotations;

namespace CANNESCAKE.Models
{
    public class Subscriber : BaseEntity
    {

        [Required(ErrorMessage = "E-poçt daxil edin")]
        [EmailAddress(ErrorMessage = "Düzgün e-poçt ünvanı daxil edin")]
        [StringLength(200)]
        public string Email { get; set; } = string.Empty;

        public DateTime SubscribedDate { get; set; } = DateTime.Now;

        public bool IsActive { get; set; } = true;
    }
}
