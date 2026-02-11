using Microsoft.AspNetCore.Mvc;

namespace CANNESCAKE.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
