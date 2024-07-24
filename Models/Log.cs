using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeLogger.Models
{
    public class Log
    {
        [Key]
        public int Id { get; set; }
        public string? StartTime { get; set; }
        public string? EndTime { get; set; }
        public string? TaskTitle { get; set; }
        public string? TaskDescription { get; set; }

        [ForeignKey("Day")]
        public int DayId { get; set; }
        public Day Day { get; set; } = new Day();
    }
}
