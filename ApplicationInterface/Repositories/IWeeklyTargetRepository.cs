public interface IWeeklyTargetRepository
{
    Task<List<WeeklyTarget>> GetAllWeeklyTargetsAsync();
    Task<WeeklyTarget> GetWeeklyTargetByIdAsync(string id);
    Task CreateWeeklyTargetAsync(WeeklyTarget weeklyTarget);
    Task UpdateWeeklyTargetAsync(string id, WeeklyTarget weeklyTarget);
    Task DeleteWeeklyTargetAsync(string id);
}