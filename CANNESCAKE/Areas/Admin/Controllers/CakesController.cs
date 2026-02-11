using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CANNESCAKE.Data;
using CANNESCAKE.Models;

namespace CANNESCAKE.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CakesController : Controller
    {
        private readonly AppDbContext _context;

        public CakesController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var cakes = _context.Cakes.Include(c => c.Category);
            return View(await cakes.ToListAsync());
        }
    }
}
