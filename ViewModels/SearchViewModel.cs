using TimeLogger.Models;

namespace TimeLogger.ViewModels
{
    public class SearchViewModel
    {
        // Search term properties
        public bool IsDateSearch { get; set; }
        public bool IsWeekSearch { get; set; }
        public string? SearchTermText { get; set; }
        
        // Search properties
        public DateOnly? Date { get; set; }
        public int? WeekNumber { get; set; }
        public int? Year { get; set; }

        // Search results
        public Week? Week { get; set; }

        // Error
        public Error Error { get; set; } = new Error();
    }
}
