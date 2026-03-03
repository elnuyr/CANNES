using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CANNESCAKE.Data;

namespace CANNESCAKE.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.TeamMembers = await _context.TeamMembers
                .OrderBy(t => t.DisplayOrder)
                .ToListAsync();

            ViewBag.Testimonials = await _context.Testimonials
                .Where(t => t.IsApproved)
                .OrderByDescending(t => t.CreatedDate)
                .ToListAsync();

            ViewBag.Categories = await _context.Categories
                .Include(c => c.Cakes.Where(cake => cake.IsAvailable))
                .ToListAsync();

            return View();
        }
    }
}
