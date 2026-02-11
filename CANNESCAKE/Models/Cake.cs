using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CANNESCAKE.Models
{
    public class Cake : BaseEntity
    {


        [Required(ErrorMessage = "Tort adı daxil edilməlidir")]
        [StringLength(200)]
        public string Name { get; set; } = string.Empty;

        [StringLength(1000)]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Qiymət daxil edilməlidir")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [StringLength(500)]
        public string? ImageUrl { get; set; }

        public bool IsAvailable { get; set; } = true;

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        // Foreign key
        [Required(ErrorMessage = "Kateqoriya seçilməlidir")]
        public int CategoryId { get; set; }

        // Navigation property
        public Category? Category { get; set; }

        // Navigation property
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
