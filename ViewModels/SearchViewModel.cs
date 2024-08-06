namespace TimeLogger.ViewModels
{
    public class SearchViewModel
    {
        public bool IsDateSearch { get; set; }
        public bool IsWeekSearch { get; set; }
        public string SearchTermText { get; set; } = "Search term";
    }
}
