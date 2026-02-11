using System.ComponentModel.DataAnnotations;

namespace CANNESCAKE.Models
{
    public class TeamMember : BaseEntity
    {

        [Required(ErrorMessage = "Ad daxil edilməlidir")]
        [StringLength(100)]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Vəzifə daxil edilməlidir")]
        [StringLength(100)]
        public string Position { get; set; } = string.Empty;

        [StringLength(500)]
        public string? ImageUrl { get; set; }

        [StringLength(200)]
        public string? FacebookUrl { get; set; }

        [StringLength(200)]
        public string? TwitterUrl { get; set; }

        [StringLength(200)]
        public string? InstagramUrl { get; set; }

        public int DisplayOrder { get; set; } = 0;
    }
}
