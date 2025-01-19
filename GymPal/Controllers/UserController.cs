using Microsoft.AspNetCore.Mvc;

namespace GymPal.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
