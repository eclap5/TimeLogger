using Microsoft.EntityFrameworkCore;

namespace TimeLogger.Models.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Week> Weeks { get; set; }
        public DbSet<Log> Logs { get; set; }
    }
}
