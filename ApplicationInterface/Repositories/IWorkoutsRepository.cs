public interface IWorkouts
{
    Task<List<Workouts>> GetAllWorkoutsAsync();
    Task<Workouts> GetWorkoutByIdAsync(string id);
    Task CreateWorkoutAsync(Workouts workout);
    Task UpdateWorkoutAsync(string id, Workouts workout);
    Task DeleteWorkoutAsync(string id);

}