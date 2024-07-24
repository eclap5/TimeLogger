using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeLogger.Models
{
    public class Day
    {
        [Key]
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public string? WeekDay { get; set; }
        
        [ForeignKey("Week")]
        public int WeekId { get; set; }
        public List<Log> Logs { get; set; } = [];
        public Week Week { get; set; } = new Week();
    }
}
