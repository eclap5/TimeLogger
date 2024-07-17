using Microsoft.AspNetCore.Mvc;
using TimeLogger.Interfaces;
using TimeLogger.Models;

namespace TimeLogger.Controllers
{
    public class LogController(ILogRepository logRepository) : Controller
    {
        private readonly ILogRepository _logRepository = logRepository;

        public async Task<IActionResult> Index()
        {
            DateOnly currentDate = DateOnly.FromDateTime(DateTime.Now);

            IEnumerable<Log> logs = await _logRepository.GetLogsByDateAsync(currentDate);

            return View(logs);
        }
    }
}
