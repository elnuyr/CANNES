using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CANNESCAKE.Data;

namespace CANNESCAKE.Controllers
{
    public class TeamController : Controller
    {
        private readonly AppDbContext _context;

        public TeamController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var teamMembers = await _context.TeamMembers
                .OrderBy(t => t.DisplayOrder)
                .ToListAsync();
            return View(teamMembers);
        }
    }
}
