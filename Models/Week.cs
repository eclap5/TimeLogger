using System.ComponentModel.DataAnnotations;

namespace TimeLogger.Models
{
    public class Week
    {
        [Key]
        public int Id { get; set; }
        public string WeekNumber { get; set; }
        public List<Log> Logs { get; set; }
    }
}
