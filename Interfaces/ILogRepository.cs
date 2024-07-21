using TimeLogger.Models;

namespace TimeLogger.Interfaces
{
    public interface ILogRepository
    {
        Task<IEnumerable<Log>> GetLogsAsync();
        Task<IEnumerable<Log>> GetLogsByDateAsync(DateOnly date);
        Task<IEnumerable<Log>> GetLogsByDayIdAsync(int dayId);
        Task<IEnumerable<Log>> GetLogsByWeekIdAsync(int weekId);
        Task<Log?> GetLogByIdAsync(int id);
        Task<Log> AddLogAsync(Log log);
        Task<bool> UpdateLogAsync(Log log);
        Task<bool> DeleteLogAsync(Log log);
        Task<bool> SaveAsync();
    }
}
