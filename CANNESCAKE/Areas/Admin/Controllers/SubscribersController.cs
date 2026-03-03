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

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var subscriber = await _context.Subscribers.FirstOrDefaultAsync(s => s.Id == id);
            if (subscriber == null) return NotFound();
            return View(subscriber);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subscriber = await _context.Subscribers.FindAsync(id);
            if (subscriber != null)
            {
                _context.Subscribers.Remove(subscriber);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
