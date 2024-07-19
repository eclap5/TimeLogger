using TimeLogger.Models;

namespace TimeLogger.Interfaces
{
    public interface IDayRepository
    {
        Task<IEnumerable<Day>> GetDaysAsync();
        Task<IEnumerable<Day>> GetDaysByWeekIdAsync(int weekId);
        Task<Day?> GetDayByIdAsync(int id);
        Task<Day?> GetDayByDateAsync(DateOnly? date);
        Task<bool> AddDayAsync(Day day);
        Task<bool> UpdateDayAsync(Day day);
        Task<bool> DeleteDayAsync(Day day);
        Task<bool> SaveAsync();
    }
}
