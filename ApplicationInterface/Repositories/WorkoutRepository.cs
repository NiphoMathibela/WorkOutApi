using MongoDB.Driver;

public class WorkoutsRepository : IWorkouts
{
    private readonly IMongoCollection<Workouts> _workoutsCollection;

    public WorkoutsRepository(IConfiguration configuration, IMongoClient mongoClient)
    {
        var dbName = configuration["MongoDBSettings:DatabaseName"];
        var database = mongoClient.GetDatabase(dbName);
        _workoutsCollection = database.GetCollection<Workouts>("Workouts");
    }

    public async Task<List<Workouts>> GetAllWorkoutsAsync()
    {
        return await _workoutsCollection.Find(_ => true).ToListAsync();
    }

    public async Task<Workouts> GetWorkoutByIdAsync(string id)
    {
        return await _workoutsCollection.Find(workout => workout.Id == id).FirstOrDefaultAsync();
    }

    public async Task CreateWorkoutAsync(Workouts workout)
    {
        await _workoutsCollection.InsertOneAsync(workout);
    }

    public async Task UpdateWorkoutAsync(string id, Workouts workout)
    {
        await _workoutsCollection.ReplaceOneAsync(w => w.Id == id, workout);
    }

    public async Task DeleteWorkoutAsync(string id)
    {
        await _workoutsCollection.DeleteOneAsync(w => w.Id == id);
    }
}