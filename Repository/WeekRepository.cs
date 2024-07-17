using Microsoft.EntityFrameworkCore;
using TimeLogger.Data;
using TimeLogger.Interfaces;
using TimeLogger.Models;

namespace TimeLogger.Repository
{
    public class WeekRepository(ApplicationDbContext context) : IWeekRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<bool> AddWeekAsync(Week week)
        {
            await _context.AddAsync(week);
            return await SaveAsync();
        }

        public async Task<bool> DeleteWeekAsync(Week week)
        {
            _context.Remove(week);
            return await SaveAsync();
        }

        public async Task<Week?> GetWeekByIdAsync(int id)
        {
            return await _context.Weeks.FindAsync(id);
        }

        public async Task<IEnumerable<Week>> GetWeeksAsync()
        {
            return await _context.Weeks.ToListAsync();
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateWeekAsync(Week week)
        {
            _context.Update(week);
            return await SaveAsync();
        }
    }
}
