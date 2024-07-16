using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeLogger.Data;

namespace TimeLogger.Controllers
{
    public class LogController(ApplicationDbContext dbContext) : Controller
    {
        private readonly ApplicationDbContext _dbContext = dbContext;

        public IActionResult Index()
        {
            var logs = _dbContext.Logs.Include(d => d.Day).ToList();

            return View(logs);
        }
    }
}
