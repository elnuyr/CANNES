using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CANNESCAKE.Data;
using CANNESCAKE.Models;

namespace CANNESCAKE.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrdersController : Controller
    {
        private readonly AppDbContext _context;

        public OrdersController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Orders.Include(o => o.OrderItems).ThenInclude(oi => oi.Cake).OrderByDescending(o => o.OrderDate).ToListAsync());
        }
    }
}
