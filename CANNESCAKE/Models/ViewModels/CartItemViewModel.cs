namespace CANNESCAKE.Models.ViewModels
{
    public class CartItemViewModel
    {
        public int CakeId { get; set; }
        public string CakeName { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; } = 1;
        public decimal TotalPrice => Price * Quantity;
    }

    public class CheckoutViewModel
    {
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerEmail { get; set; } = string.Empty;
        public string CustomerPhone { get; set; } = string.Empty;
        public string? DeliveryAddress { get; set; }
        public string? Notes { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public List<CartItemViewModel> CartItems { get; set; } = new();
        public decimal GrandTotal => CartItems.Sum(x => x.TotalPrice);
    }
}
