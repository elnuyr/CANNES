using Microsoft.AspNetCore.Mvc;

namespace CANNESCAKE.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
