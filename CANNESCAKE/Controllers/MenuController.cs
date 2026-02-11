using Microsoft.AspNetCore.Mvc;

namespace CANNESCAKE.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
