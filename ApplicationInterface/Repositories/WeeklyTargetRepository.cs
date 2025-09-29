using MongoDB.Driver;

public class WeeklyTargetRepository : IWeeklyTargetRepository
{
    private readonly IMongoCollection<WeeklyTarget> _weeklyTargets;

    public WeeklyTargetRepository(IMongoDatabase database)
    {
        _weeklyTargets = database.GetCollection<WeeklyTarget>("WeeklyTargets");
    }

    public async Task<List<WeeklyTarget>> GetAllWeeklyTargetsAsync()
    {
        return await _weeklyTargets.Find(_ => true).ToListAsync();
    }

    public async Task<WeeklyTarget> GetWeeklyTargetByIdAsync(string id)
    {
        return await _weeklyTargets.Find(target => target.Id == id).FirstOrDefaultAsync();
    }

    public async Task CreateWeeklyTargetAsync(WeeklyTarget target)
    {
        await _weeklyTargets.InsertOneAsync(target);
    }

    public async Task UpdateWeeklyTargetAsync(string id, WeeklyTarget target)
    {
        await _weeklyTargets.ReplaceOneAsync(t => t.Id == id, target);
    }

    public async Task DeleteWeeklyTargetAsync(string id)
    {
        await _weeklyTargets.DeleteOneAsync(t => t.Id == id);
    }
}