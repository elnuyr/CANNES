using Microsoft.AspNetCore.Mvc;
using CANNESCAKE.Data;
using CANNESCAKE.Models;

namespace CANNESCAKE.Controllers
{
    public class ContactController : Controller
    {
        private readonly AppDbContext _context;

        public ContactController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(ContactMessage message)
        {
            if (ModelState.IsValid)
            {
                _context.ContactMessages.Add(message);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Mesajınız uğurla göndərildi!";
                return RedirectToAction(nameof(Index));
            }
            return View(message);
        }
    }
}
