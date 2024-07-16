using Microsoft.EntityFrameworkCore;
using TimeLogger.Models;

namespace TimeLogger.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Week> Weeks { get; set; }
        public DbSet<Day> Days { get; set; }
        public DbSet<Log> Logs { get; set; }
    }
}
