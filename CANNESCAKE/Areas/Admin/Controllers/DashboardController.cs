using CANNESCAKE.Data;
using CANNESCAKE.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CANNESCAKE.Areas.Admin.Controllers
{
    public class DashboardController : AdminBaseController
    {
        private readonly AppDbContext _context;

        public DashboardController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var model = new DashboardViewModel
            {
                CategoriesCount = await _context.Categories.CountAsync(),
                CakesCount = await _context.Cakes.CountAsync(),
                OrdersCount = await _context.Orders.CountAsync(),
                SubscribersCount = await _context.Subscribers.CountAsync(),
                TestimonialsCount = await _context.Testimonials.CountAsync(),
                MessagesCount = await _context.ContactMessages.CountAsync(),
                RecentOrders = await _context.Orders
                    .OrderByDescending(o => o.OrderDate)
                    .Take(5)
                    .ToListAsync(),
                RecentMessages = await _context.ContactMessages
                    .OrderByDescending(m => m.CreatedDate)
                    .Take(5)
                    .ToListAsync()
            };

            return View(model);
        }
    }
}
