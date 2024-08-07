namespace TimeLogger.ViewModels
{
    public class SearchViewModel
    {
        // Search term properties
        public bool IsDateSearch { get; set; }
        public bool IsWeekSearch { get; set; }
        public string SearchTermText { get; set; } = "Search term";
        
        // Search properties
        public DateOnly? Date { get; set; }
        public int? WeekNumber { get; set; }
        public int? Year { get; set; }
    }
}
