using TimeLogger.Models;

namespace TimeLogger.ViewModels
{
    public class LogViewModel
    {
        public Log? NewLog { get; set; }
        public IEnumerable<Log>? Logs { get; set; }
        public IEnumerable<Day>? Days { get; set; }
        public IEnumerable<Week>? Weeks { get; set; }
    }
}
