using Microsoft.AspNetCore.Mvc;

namespace TimeLogger.Controllers
{
    public class LogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
