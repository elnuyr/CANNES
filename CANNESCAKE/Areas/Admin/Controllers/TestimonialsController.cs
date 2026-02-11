using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CANNESCAKE.Data;
using CANNESCAKE.Models;

namespace CANNESCAKE.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TestimonialsController : Controller
    {
        private readonly AppDbContext _context;

        public TestimonialsController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Testimonials.OrderByDescending(t => t.CreatedDate).ToListAsync());
        }
    }
}
