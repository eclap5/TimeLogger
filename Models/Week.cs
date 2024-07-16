using System.ComponentModel.DataAnnotations;

namespace TimeLogger.Models
{
    public class Week
    {
        [Key]
        public int Id { get; set; }
        public int Year { get; set; }
        public int WeekNumber { get; set; }
        public List<Day>? Days { get; set; }
    }
}
