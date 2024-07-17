using Microsoft.EntityFrameworkCore;
using TimeLogger.Data;
using TimeLogger.Interfaces;
using TimeLogger.Models;

namespace TimeLogger.Repository
{
    public class LogRepository(ApplicationDbContext context) : ILogRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<bool> AddLogAsync(Log log)
        {
            await _context.AddAsync(log);
            return await SaveAsync();
        }

        public async Task<bool> DeleteLogAsync(Log log)
        {
            _context.Remove(log);
            return await SaveAsync();
        }

        public async Task<Log?> GetLogByIdAsync(int id)
        {
            return await _context.Logs.FindAsync(id);
        }

        public async Task<IEnumerable<Log>> GetLogsAsync()
        {
            return await _context.Logs.ToListAsync();
        }

        public async Task<IEnumerable<Log>> GetLogsByDateAsync(DateOnly date)
        {
            return await _context.Logs.Include(log => log.Day).Where(log => log.Day != null && log.Day.Date == date).ToListAsync();
        }

        public async Task<IEnumerable<Log>> GetLogsByDayIdAsync(int dayId)
        {
            return await _context.Logs.Where(d => d.Id == dayId).ToListAsync();
        }

        public async Task<IEnumerable<Log>> GetLogsByWeekIdAsync(int weekId)
        {
            return await _context.Logs.Include(log => log.Day).Where(log => log.Day != null && log.Day.WeekId == weekId).ToListAsync();
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateLogAsync(Log log)
        {
            _context.Update(log);
            return await SaveAsync();
        }
    }
}
