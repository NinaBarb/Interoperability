using Microsoft.AspNetCore.Mvc;

namespace Zadatak07.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
