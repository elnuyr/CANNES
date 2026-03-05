using CANNESCAKE.Data;
using CANNESCAKE.Models;
using CANNESCAKE.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace CANNESCAKE.Controllers
{
    public class BasketController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private const string CartSessionKey = "ShoppingCart";

        public BasketController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // Səbəti göstər
        public IActionResult Index()
        {
            var cart = GetCart();
            return View(cart);
        }

        // Səbətə məhsul əlavə et (AJAX)
        [HttpPost]
        public async Task<IActionResult> AddToCart(int cakeId, int quantity = 1)
        {
            var cake = await _context.Cakes.FindAsync(cakeId);
            if (cake == null || !cake.IsAvailable)
            {
                return Json(new { success = false, message = "Məhsul tapılmadı." });
            }

            var cart = GetCart();
            var existingItem = cart.FirstOrDefault(x => x.CakeId == cakeId);

            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                cart.Add(new CartItemViewModel
                {
                    CakeId = cake.Id,
                    CakeName = cake.Name,
                    ImageUrl = cake.ImageUrl,
                    Price = cake.Price,
                    Quantity = quantity
                });
            }

            SaveCart(cart);
            return Json(new { success = true, message = "Məhsul səbətə əlavə edildi!", cartCount = cart.Sum(x => x.Quantity) });
        }

        // Səbətdən məhsul sil
        [HttpPost]
        public IActionResult RemoveFromCart(int cakeId)
        {
            var cart = GetCart();
            var item = cart.FirstOrDefault(x => x.CakeId == cakeId);
            if (item != null)
            {
                cart.Remove(item);
                SaveCart(cart);
            }
            return RedirectToAction("Index");
        }

        // Miqdarı yenilə
        [HttpPost]
        public IActionResult UpdateQuantity(int cakeId, int quantity)
        {
            var cart = GetCart();
            var item = cart.FirstOrDefault(x => x.CakeId == cakeId);
            if (item != null)
            {
                if (quantity <= 0)
                {
                    cart.Remove(item);
                }
                else
                {
                    item.Quantity = quantity;
                }
                SaveCart(cart);
            }
            return RedirectToAction("Index");
        }

        // Səbət sayını JSON olaraq qaytar (AJAX)
        [HttpGet]
        public IActionResult GetCartCount()
        {
            var cart = GetCart();
            return Json(new { count = cart.Sum(x => x.Quantity) });
        }

        // Checkout - YALNIZ qeydiyyatlı istifadəçilər üçün
        [Authorize]
        public async Task<IActionResult> Checkout()
        {
            var cart = GetCart();
            if (!cart.Any())
            {
                TempData["ErrorMessage"] = "Səbətiniz boşdur. Əvvəlcə məhsul əlavə edin.";
                return RedirectToAction("Index");
            }

            var user = await _userManager.GetUserAsync(User);
            var model = new CheckoutViewModel
            {
                CustomerName = user?.FullName ?? "",
                CustomerEmail = user?.Email ?? "",
                CartItems = cart
            };

            return View(model);
        }

        // Sifarişi tamamla - YALNIZ qeydiyyatlı istifadəçilər üçün
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PlaceOrder(CheckoutViewModel model)
        {
            var cart = GetCart();
            if (!cart.Any())
            {
                TempData["ErrorMessage"] = "Səbətiniz boşdur.";
                return RedirectToAction("Index");
            }

            var user = await _userManager.GetUserAsync(User);

            var order = new Order
            {
                UserId = user!.Id,
                CustomerName = model.CustomerName,
                CustomerEmail = model.CustomerEmail,
                CustomerPhone = model.CustomerPhone,
                DeliveryAddress = model.DeliveryAddress,
                Notes = model.Notes,
                DeliveryDate = model.DeliveryDate,
                TotalPrice = cart.Sum(x => x.TotalPrice),
                OrderDate = DateTime.Now,
                Status = OrderStatus.Gözləmədə
            };

            foreach (var item in cart)
            {
                order.OrderItems.Add(new OrderItem
                {
                    CakeId = item.CakeId,
                    Quantity = item.Quantity,
                    UnitPrice = item.Price,
                    TotalPrice = item.TotalPrice
                });
            }

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            // Səbəti təmizlə
            HttpContext.Session.Remove(CartSessionKey);

            TempData["SuccessMessage"] = "Sifarişiniz uğurla qəbul edildi! Sifariş nömrəniz: #" + order.Id;
            return RedirectToAction("OrderConfirmation", new { id = order.Id });
        }

        // Sifariş təsdiqi səhifəsi
        [Authorize]
        public async Task<IActionResult> OrderConfirmation(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            var order = await _context.Orders
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Cake)
                .FirstOrDefaultAsync(o => o.Id == id && o.UserId == user!.Id);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // Session-dan səbəti oxu
        private List<CartItemViewModel> GetCart()
        {
            var cartJson = HttpContext.Session.GetString(CartSessionKey);
            if (string.IsNullOrEmpty(cartJson))
            {
                return new List<CartItemViewModel>();
            }
            return JsonSerializer.Deserialize<List<CartItemViewModel>>(cartJson) ?? new List<CartItemViewModel>();
        }

        // Session-a səbəti yaz
        private void SaveCart(List<CartItemViewModel> cart)
        {
            var cartJson = JsonSerializer.Serialize(cart);
            HttpContext.Session.SetString(CartSessionKey, cartJson);
        }
    }
}
