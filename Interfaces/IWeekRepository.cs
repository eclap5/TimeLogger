using TimeLogger.Models;

namespace TimeLogger.Interfaces
{
    public interface IWeekRepository
    {
        Task<IEnumerable<Week>> GetWeeksAsync();
        Task<Week?> GetWeekByIdAsync(int id);
        Task<bool> AddWeekAsync(Week week);
        Task<bool> UpdateWeekAsync(Week week);
        Task<bool> DeleteWeekAsync(Week week);
        Task<bool> SaveAsync();
    }
}
