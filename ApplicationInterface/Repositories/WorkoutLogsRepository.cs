using MongoDB.Driver;

public class WorkoutLogsRepository : IWorkoutLogsRepository
{
    private readonly IMongoCollection<WorkoutLogs> _workoutLogsCollection;

    public WorkoutLogsRepository(IConfiguration configuration, IMongoClient mongoClient)
    {
        var dbName = configuration["MongoDBSettings:DatabaseName"];
        var database = mongoClient.GetDatabase(dbName);
        _workoutLogsCollection = database.GetCollection<WorkoutLogs>("WorkoutLogs");
    }

    public async Task<List<WorkoutLogs>> GetAllWorkoutLogsAsync()
    {
        return await _workoutLogsCollection.Find(_ => true).ToListAsync();
    }

    public async Task<WorkoutLogs> GetWorkoutLogByIdAsync(string id)
    {
        return await _workoutLogsCollection.Find(log => log.Id == id).FirstOrDefaultAsync();
    }

    public async Task CreateWorkoutLogAsync(WorkoutLogs log)
    {
        await _workoutLogsCollection.InsertOneAsync(log);
    }

    public async Task UpdateWorkoutLogAsync(string id, WorkoutLogs log)
    {
        await _workoutLogsCollection.ReplaceOneAsync(l => l.Id == id, log);
    }

    public async Task DeleteWorkoutLogAsync(string id)
    {
        await _workoutLogsCollection.DeleteOneAsync(l => l.Id == id);
    }
}