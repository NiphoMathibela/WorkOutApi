public interface IWeightGoalRepository
{
    Task<List<WeightGoal>> GetAllWeightGoalsAsync();
    Task<WeightGoal> GetWeightGoalByIdAsync(string id);
    Task CreateWeightGoalAsync(WeightGoal weightGoal);
    Task UpdateWeightGoalAsync(string id, WeightGoal weightGoal);
    Task DeleteWeightGoalAsync(string id);
}