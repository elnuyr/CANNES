using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CANNESCAKE.Data;

namespace CANNESCAKE.Controllers
{
    public class MenuController : Controller
    {
        private readonly AppDbContext _context;

        public MenuController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string? searchTerm)
        {
            ViewData["SearchTerm"] = searchTerm;

            var categoriesQuery = _context.Categories
                .Include(c => c.Cakes.Where(cake => cake.IsAvailable))
                .AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                // Filter categories that have cakes matching the search term, 
                // and within those categories, only include the matching cakes.
                var matchingCategories = await _context.Categories
                    .Include(c => c.Cakes.Where(cake => cake.IsAvailable && (cake.Name.Contains(searchTerm) || cake.Description.Contains(searchTerm))))
                    .Where(c => c.Cakes.Any(cake => cake.IsAvailable && (cake.Name.Contains(searchTerm) || cake.Description.Contains(searchTerm))))
                    .ToListAsync();
                
                return View(matchingCategories);
            }

            var allCategories = await categoriesQuery.ToListAsync();
            return View(allCategories);
        }
    }
}
