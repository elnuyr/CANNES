using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CANNESCAKE.Models
{
    public class OrderItem : BaseEntity
    {


        [Required]
        public int OrderId { get; set; }

        [Required]
        public int CakeId { get; set; }

        [Required]
        [Range(1, 100)]
        public int Quantity { get; set; } = 1;

        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }

        // Navigation properties
        public Order? Order { get; set; }
        public Cake? Cake { get; set; }
    }
}
