using Microsoft.AspNetCore.Mvc;

namespace CANNESCAKE.Controllers
{
    public class HomeController : Controller
    {
        

        public IActionResult Index()
        {
            return View();
        }

        
    }
}
