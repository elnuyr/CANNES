using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CANNESCAKE.Data;
using CANNESCAKE.Models;

namespace CANNESCAKE.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TeamMembersController : Controller
    {
        private readonly AppDbContext _context;

        public TeamMembersController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.TeamMembers.OrderBy(t => t.DisplayOrder).ToListAsync());
        }
    }
}
