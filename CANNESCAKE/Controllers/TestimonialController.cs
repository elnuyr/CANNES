using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CANNESCAKE.Data;

namespace CANNESCAKE.Controllers
{
    public class TestimonialController : Controller
    {
        private readonly AppDbContext _context;

        public TestimonialController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var testimonials = await _context.Testimonials
                .Where(t => t.IsApproved)
                .OrderByDescending(t => t.CreatedDate)
                .ToListAsync();
            return View(testimonials);
        }
    }
}
