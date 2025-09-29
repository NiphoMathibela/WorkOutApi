using MongoDB.Driver;

public class WeightGoalRepository : IWeightGoalRepository
{
    private readonly IMongoCollection<WeightGoal> _weightGoalCollection;

    public WeightGoalRepository(IConfiguration configuration, IMongoClient mongoClient)
    {
        var dbName = configuration["MongoDBSettings:DatabaseName"];
        var database = mongoClient.GetDatabase(dbName);
        _weightGoalCollection = database.GetCollection<WeightGoal>("WeightGoals");
    }

    public async Task<List<WeightGoal>> GetAllWeightGoalsAsync()
    {
        return await _weightGoalCollection.Find(_ => true).ToListAsync();
    }

    public async Task<WeightGoal> GetWeightGoalByIdAsync(string id)
    {
        return await _weightGoalCollection.Find(goal => goal.Id == id).FirstOrDefaultAsync();
    }

    public async Task CreateWeightGoalAsync(WeightGoal weightGoal)
    {
        await _weightGoalCollection.InsertOneAsync(weightGoal);
    }

    public async Task UpdateWeightGoalAsync(string id, WeightGoal weightGoal)
    {
        await _weightGoalCollection.ReplaceOneAsync(g => g.Id == id, weightGoal);
    }

    public async Task DeleteWeightGoalAsync(string id)
    {
        await _weightGoalCollection.DeleteOneAsync(g => g.Id == id);
    }
}