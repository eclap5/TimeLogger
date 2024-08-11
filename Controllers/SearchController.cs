using Microsoft.AspNetCore.Mvc;
using TimeLogger.Common;
using TimeLogger.Interfaces;
using TimeLogger.Models;
using TimeLogger.ViewModels;

namespace TimeLogger.Controllers
{
    public class SearchController(ILogRepository logRepository, IDayRepository dayRepository, IWeekRepository weekRepository) : Controller
    {
        private readonly ILogRepository _logRepository = logRepository;
        private readonly IDayRepository _dayRepository = dayRepository;
        private readonly IWeekRepository _weekRepository = weekRepository;

        public async Task<IActionResult> Index()
        {
            SearchViewModel searchViewModel = await GetSearchViewModel();
            return View(searchViewModel);
        }

        public IActionResult SearchTerm(SearchViewModel searchViewModel)
        {
            if (searchViewModel.IsDateSearch)
            {
                searchViewModel.SearchTermText = "By date";
            }
            else if (searchViewModel.IsWeekSearch)
            {
                searchViewModel.SearchTermText = "By week";
            }

            return View("Index", searchViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Search(SearchViewModel searchViewModel)
        {
            if (!ModelState.IsValid)
            {
                searchViewModel.Error = new Error()
                {
                    IsError = true,
                    StatusCode = "400",
                    Message = "Invalid model state"
                };
                return View("Index", searchViewModel);
            }

            if (searchViewModel.IsDateSearch)
            {
                if (searchViewModel.Date != null)
                {
                    DateOnly date = (DateOnly)searchViewModel.Date;
                    int weekNum = Utilities.GetWeekNumber(date);
                    int year = Utilities.GetYear(date);
                    Week? week = await GetWeekLogs(weekNum, year);
                    
                    if (week != null)
                    {
                        searchViewModel.Week = week;
                    }
                    else
                    {
                        searchViewModel.Error = new Error()
                        {
                            IsError = true,
                            StatusCode = "404",
                            Message = "No logs found for the specified date"
                        };
                    }
                }
            }
            else if (searchViewModel.IsWeekSearch)
            {
                if (searchViewModel.WeekNumber != null && searchViewModel.Year != null)
                {
                    int weekNum = (int)searchViewModel.WeekNumber;
                    int year = (int)searchViewModel.Year;

                    Week? week = await GetWeekLogs(weekNum, year);
                    if (week != null)
                    {
                        searchViewModel.Week = week;
                    }
                    else
                    {
                        searchViewModel.Error = new Error()
                        {
                            IsError = true,
                            StatusCode = "404",
                            Message = "No logs found for the specified week"
                        };
                    }
                } 
            }
            return View("Index", searchViewModel);
        }

        private async Task<SearchViewModel> GetSearchViewModel()
        {
            DateOnly date = DateOnly.FromDateTime(DateTime.Now);
            int weekNum = Utilities.GetWeekNumber(date);
            int year = Utilities.GetYear(date);

            Week? week = await GetWeekLogs(weekNum, year);

            SearchViewModel searchViewModel = new()
            {
                Error = new Error() { IsError = false },
                SearchTermText = "Search term",
                IsDateSearch = false,
                IsWeekSearch = false,
                Week = week
            };

            return searchViewModel;
        }

        private async Task<Week?> GetWeekLogs(int weekNum, int year)
        {
            Week? week = await _weekRepository.GetWeekByWeekNumAndYearAsync(weekNum, year);
            if (week != null)
            {
                List<Day> days = await _dayRepository.GetDaysByWeekIdAsync(week.Id);
                days = days.OrderBy(day => day.Date).ToList();

                foreach (Day day in days)
                {
                    day.Logs = await _logRepository.GetLogsByDayIdAsync(day.Id);
                }
                week.Days = days;
            }
            return week;
        }
    }
}
