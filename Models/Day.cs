﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeLogger.Models
{
    public class Day
    {
        [Key]
        public int Id { get; set; }
        public DateOnly Date { get; set; } = new DateOnly(0001, 1, 1);
        public string? WeekDay { get; set; }
        
        [ForeignKey("Week")]
        public int WeekId { get; set; }
        public List<Log>? Logs { get; set; }
    }
}
