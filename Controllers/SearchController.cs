using Microsoft.AspNetCore.Mvc;
using TimeLogger.Interfaces;
using TimeLogger.ViewModels;

namespace TimeLogger.Controllers
{
    public class SearchController(ILogRepository logRepository, IDayRepository dayRepository, IWeekRepository weekRepository) : Controller
    {
        private readonly ILogRepository _logRepository = logRepository;
        private readonly IDayRepository _dayRepository = dayRepository;
        private readonly IWeekRepository _weekRepository = weekRepository;

        public IActionResult Index()
        {
            SearchViewModel searchViewModel = GetSearchViewModel();
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

        private static SearchViewModel GetSearchViewModel()
        {
            SearchViewModel searchViewModel = new()
            {
                IsDateSearch = false,
                IsWeekSearch = false
            };

            return searchViewModel;
        }
    }
}
