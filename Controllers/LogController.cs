using Microsoft.AspNetCore.Mvc;
using TimeLogger.Models.Data;

namespace TimeLogger.Controllers
{
    public class LogController(ApplicationDbContext dbContext) : Controller
    {
        private readonly ApplicationDbContext _dbContext = dbContext;

        public IActionResult Index()
        {
            var logs = _dbContext.Logs.ToList();

            return View(logs);
        }
    }
}
