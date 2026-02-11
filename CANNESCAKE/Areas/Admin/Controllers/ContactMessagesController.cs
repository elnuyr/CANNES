using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CANNESCAKE.Data;
using CANNESCAKE.Models;

namespace CANNESCAKE.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactMessagesController : Controller
    {
        private readonly AppDbContext _context;

        public ContactMessagesController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.ContactMessages.OrderByDescending(m => m.CreatedDate).ToListAsync());
        }
    }
}
