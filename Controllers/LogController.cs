using Microsoft.AspNetCore.Mvc;
using System.Globalization;
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

            DateOnly date = logViewModel.NewLog!.Day!.Date!;
            Day? day = await _dayRepository.GetDayByDateAsync(date);

            if (day == null)
            {
                int weekNum = GetWeekNumber(date);
                Week? week = await _weekRepository.GetWeekByWeekNumAsync(weekNum);
                
                if (week == null)
                {
                    Week newWeek = new()
                    {
                        WeekNumber = weekNum,
                        Year = GetYear(),
                        Days = []
                    };
                    await _weekRepository.AddWeekAsync(newWeek);
                }

                await _dayRepository.AddDayAsync(day);
            }

            await _logRepository.AddLogAsync(logViewModel.NewLog);
            return View();
        }

        private async Task<LogViewModel> GetLogViewModel()
        {
            DateOnly currentDate = DateOnly.FromDateTime(DateTime.Now);

            LogViewModel logView = new()
            {
                NewLog = new Log() { Day = new() },
                Logs = await _logRepository.GetLogsByDateAsync(currentDate),
                Days = await _dayRepository.GetDaysAsync(),
                Weeks = await _weekRepository.GetWeeksAsync()
            };

            return logView;
        }

        private static int GetWeekNumber(DateOnly dateOnly)
        {
            Calendar calendar = CultureInfo.CurrentCulture.Calendar;
            
            CalendarWeekRule calendarWeekRule = CalendarWeekRule.FirstFourDayWeek;
            DayOfWeek firstDayOfWeek = DayOfWeek.Monday;

            string strDateOnly = dateOnly.ToString()!;
            DateTime date = DateTime.Parse(strDateOnly);
            int weekNum = calendar.GetWeekOfYear(date, calendarWeekRule, firstDayOfWeek);
                
            return weekNum;
        }

        private static int GetYear()
        {
            Calendar calendar = CultureInfo.CurrentCulture.Calendar;
            return calendar.GetYear(DateTime.Now);
        }
    }
}
