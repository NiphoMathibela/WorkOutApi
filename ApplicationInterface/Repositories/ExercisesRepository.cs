using MongoDB.Driver;

public class ExercisesRepository
{
    private readonly IMongoCollection<Exercises> _exercisesCollection;

    public ExercisesRepository(IConfiguration configuration, IMongoClient mongoClient)
    {
        var dbName = configuration["MongoDBSettings:DatabaseName"];
        var database = mongoClient.GetDatabase(dbName);
        _exercisesCollection = database.GetCollection<Exercises>("Exercises");
    }

    public async Task<List<Exercises>> GetAllExercisesAsync()
    {
        return await _exercisesCollection.Find(_ => true).ToListAsync();
    }

    public async Task<Exercises> GetExerciseByIdAsync(string id)
    {
        return await _exercisesCollection.Find(exercise => exercise.Id == id).FirstOrDefaultAsync();
    }

    public async Task CreateExerciseAsync(Exercises exercise)
    {
        await _exercisesCollection.InsertOneAsync(exercise);
    }

    public async Task UpdateExerciseAsync(string id, Exercises exercise)
    {
        await _exercisesCollection.ReplaceOneAsync(e => e.Id == id, exercise);
    }

    public async Task DeleteExerciseAsync(string id)
    {
        await _exercisesCollection.DeleteOneAsync(e => e.Id == id);
    }
}