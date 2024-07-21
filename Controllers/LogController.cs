using Microsoft.AspNetCore.Mvc;
using TimeLogger.Common;
using TimeLogger.Interfaces;
using TimeLogger.Models;
using TimeLogger.ViewModels;

namespace TimeLogger.Controllers
{
    public class LogController(ILogRepository logRepository, IDayRepository dayRepository, IWeekRepository weekRepository) : Controller
    {
        private readonly ILogRepository _logRepository = logRepository;
        private readonly IDayRepository _dayRepository = dayRepository;
        private readonly IWeekRepository _weekRepository = weekRepository;

        public async Task<IActionResult> Index()
        {
            LogViewModel logViewModel = await GetLogViewModel();

            return View(logViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(LogViewModel logViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            DateOnly? date = logViewModel!.Log!.Day!.Date;

            Day? day = await _dayRepository.GetDayByDateAsync(date);
            if (day == null)
            {
                int weekNum = Utilities.GetWeekNumber(date);

                Week? week = await _weekRepository.GetWeekByWeekNumAsync(weekNum);
                if (week == null)
                {
                    week = new()
                    {
                        WeekNumber = weekNum,
                        Year = Utilities.GetYear(),
                        Days = []
                    };
                    week = await _weekRepository.AddWeekAsync(week);
                }

                day = new()
                {
                    Date = date,
                    WeekDay = Utilities.GetWeekDay(date),
                    WeekId = week!.Id
                };
                day = await _dayRepository.AddDayAsync(day);
            }

            logViewModel.Log.DayId = day!.Id;
            logViewModel.Log.Day = day;

            await _logRepository.AddLogAsync(logViewModel.Log);

            return Redirect("Index");
        }

        private async Task<LogViewModel> GetLogViewModel()
        {
            DateOnly currentDate = DateOnly.FromDateTime(DateTime.Now);

            LogViewModel logView = new()
            {
                Log = new Log() { Day = new() },
                Logs = await _logRepository.GetLogsByDateAsync(currentDate),
                Days = await _dayRepository.GetDaysAsync(),
                Weeks = await _weekRepository.GetWeeksAsync()
            };

            return logView;
        }
    }
}
