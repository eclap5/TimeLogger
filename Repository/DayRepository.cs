using Microsoft.EntityFrameworkCore;
using TimeLogger.Data;
using TimeLogger.Interfaces;
using TimeLogger.Models;

namespace TimeLogger.Repository
{
    public class DayRepository(ApplicationDbContext context) : IDayRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<Day> AddDayAsync(Day day)
        {
            await _context.AddAsync(day);
            await _context.SaveChangesAsync();
            return day;
        }

        public async Task<bool> DeleteDayAsync(Day day)
        {
            _context.Remove(day);
            return await SaveAsync();
        }

        public async Task<Day?> GetDayByIdAsync(int id)
        {
            return await _context.Days.FindAsync(id);
        }

        public async Task<Day?> GetDayByDateAsync(DateOnly? date)
        {
            return await _context.Days.Where(d => d.Date == date).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Day>> GetDaysAsync()
        {
            return await _context.Days.ToListAsync();
        }

        public async Task<IEnumerable<Day>> GetDaysByWeekIdAsync(int weekId)
        {
            return await _context.Days.Where(d => d.WeekId == weekId).ToListAsync();
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateDayAsync(Day day)
        {
            _context.Update(day);
            return await SaveAsync();
        }
    }
}
