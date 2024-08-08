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
                logViewModel.Error = new Error()
                {
                    IsError = true,
                    StatusCode = "400",
                    Message = "Invalid model state"
                };
                return View("Index", logViewModel);
            }

            DateOnly date = logViewModel.Log.Day.Date;
            string startTime = logViewModel.Log.StartTime!;
            string endTime = logViewModel.Log.EndTime!;

            if (Utilities.ParseDateTime(date, startTime) > Utilities.ParseDateTime(date, endTime))
            {
                logViewModel.Error = new Error()
                {
                    IsError = true,
                    StatusCode = "400",
                    Message = "Start time cannot be greater than end time"
                };
                return View("Index", logViewModel);
            }

            Day? day = await _dayRepository.GetDayByDateAsync(date);
            if (day == null)
            {
                int weekNum = Utilities.GetWeekNumber(date);
                int year = Utilities.GetYear(date);

                Week? week = await _weekRepository.GetWeekByWeekNumAndYearAsync(weekNum, year);
                if (week == null)
                {
                    week = new()
                    {
                        WeekNumber = weekNum,
                        Year = Utilities.GetYear(date),
                        Days = []
                    };
                    week = await _weekRepository.AddWeekAsync(week);
                }

                day = new()
                {
                    Date = date,
                    WeekDay = Utilities.GetWeekDay(date),
                    WeekId = week!.Id,
                    Logs = []
                };
                day = await _dayRepository.AddDayAsync(day);
            }

            Log log = new()
            {
                Day = day,
                DayId = day.Id,
                StartTime = startTime,
                EndTime = endTime,
                TaskTitle = logViewModel.Log.TaskTitle,
                TaskDescription = logViewModel.Log.TaskDescription
            };

            await _logRepository.AddLogAsync(log);

            return Redirect("Index");
        }

        private async Task<LogViewModel> GetLogViewModel()
        {
            DateOnly currentDate = DateOnly.FromDateTime(DateTime.Now);

            LogViewModel logView = new()
            {
                Error = new Error() { IsError = false },
                Log = new Log(),
                Logs = await _logRepository.GetLogsByDateAsync(currentDate),
                Days = await _dayRepository.GetDaysAsync(),
                Weeks = await _weekRepository.GetWeeksAsync()
            };

            return logView;
        }
    }
}

