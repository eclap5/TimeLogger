using System.ComponentModel.DataAnnotations;
using TimeLogger.Models.Data.Enum;

namespace TimeLogger.Models
{
    public class Log
    {
        [Key]
        public int Id { get; set; }
        public string? StartTime { get; set; }
        public string? EndTime { get; set; }
        public DateOnly Date { get; set; }
        public string? Task { get; set; }
        public DayCategory DayCategory { get; set; }
    }
}
