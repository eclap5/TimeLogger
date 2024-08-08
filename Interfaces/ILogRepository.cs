using TimeLogger.Models;

namespace TimeLogger.Interfaces
{
    public interface ILogRepository
    {
        Task<List<Log>> GetLogsAsync();
        Task<List<Log>> GetLogsByDateAsync(DateOnly date);
        Task<List<Log>> GetLogsByDayIdAsync(int dayId);
        Task<List<Log>> GetLogsByWeekIdAsync(int weekId);
        Task<Log?> GetLogByIdAsync(int id);
        Task<Log> AddLogAsync(Log log);
        Task<bool> UpdateLogAsync(Log log);
        Task<bool> DeleteLogAsync(Log log);
        Task<bool> SaveAsync();
    }
}
