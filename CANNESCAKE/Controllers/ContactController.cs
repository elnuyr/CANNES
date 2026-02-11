using Microsoft.AspNetCore.Mvc;

namespace CANNESCAKE.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
