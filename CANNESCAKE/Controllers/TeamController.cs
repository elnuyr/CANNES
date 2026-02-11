using Microsoft.AspNetCore.Mvc;

namespace CANNESCAKE.Controllers
{
    public class TeamController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
