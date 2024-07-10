using Microsoft.AspNetCore.Mvc;

namespace TimeLogger.Controllers
{
    public class WeekController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
