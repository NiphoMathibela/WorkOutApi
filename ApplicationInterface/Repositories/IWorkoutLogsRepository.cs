public interface IWorkoutLogsRepository
{
    Task<List<WorkoutLogs>> GetAllWorkoutLogsAsync();
    Task<WorkoutLogs> GetWorkoutLogByIdAsync(string id);
    Task CreateWorkoutLogAsync(WorkoutLogs workoutLog);
    Task UpdateWorkoutLogAsync(string id, WorkoutLogs workoutLog);
    Task DeleteWorkoutLogAsync(string id);

}