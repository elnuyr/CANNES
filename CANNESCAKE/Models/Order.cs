using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CANNESCAKE.Models
{
    public class Order : BaseEntity
    {

        [Required(ErrorMessage = "Müştəri adı daxil edilməlidir")]
        [StringLength(100)]
        public string CustomerName { get; set; } = string.Empty;

        [Required(ErrorMessage = "E-poçt daxil edilməlidir")]
        [EmailAddress]
        [StringLength(200)]
        public string CustomerEmail { get; set; } = string.Empty;

        [Required(ErrorMessage = "Telefon nömrəsi daxil edilməlidir")]
        [Phone]
        [StringLength(20)]
        public string CustomerPhone { get; set; } = string.Empty;

        [StringLength(500)]
        public string? DeliveryAddress { get; set; }

        [StringLength(1000)]
        public string? Notes { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;

        public DateTime? DeliveryDate { get; set; }

        public OrderStatus Status { get; set; } = OrderStatus.Gözləmədə;

        // Navigation property
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }

    public enum OrderStatus
    {
        Gözləmədə = 0,
        Təsdiqləndi = 1,
        Hazırlanır = 2,
        Çatdırılır = 3,
        Tamamlandı = 4,
        Ləğvedildi = 5
    }
}
