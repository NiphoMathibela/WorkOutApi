public interface IExercisesRepository
{
    Task<List<Exercises>> GetAllExercisesAsync();
    Task<Exercises> GetExerciseByIdAsync(string id);
    Task CreateExerciseAsync(Exercises exercise);
    Task UpdateExerciseAsync(string id, Exercises exercise);
    Task DeleteExerciseAsync(string id);
    //Get Exercises by WorkoutId and UserId
    Task<List<Exercises>> GetExercisesByWorkoutIdAsync(string workoutId, string userId);
}