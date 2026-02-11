using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CANNESCAKE.Data;
using CANNESCAKE.Models;

namespace CANNESCAKE.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SubscribersController : Controller
    {
        private readonly AppDbContext _context;

        public SubscribersController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Subscribers.OrderByDescending(s => s.SubscribedDate).ToListAsync());
        }
    }
}
