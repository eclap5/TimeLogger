using TimeLogger.Models;

namespace TimeLogger.Interfaces
{
    public interface IWeekRepository
    {
        Task<List<Week>> GetWeeksAsync();
        Task<Week?> GetWeekByIdAsync(int id);
        Task<Week?> GetWeekByWeekNumAndYearAsync(int weekNum, int year);
        Task<Week> AddWeekAsync(Week week);
        Task<bool> UpdateWeekAsync(Week week);
        Task<bool> DeleteWeekAsync(Week week);
        Task<bool> SaveAsync();
    }
}
