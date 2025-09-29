using MongoDB.Driver;

public class UserRepository : IUsersRepository
{
    private readonly IMongoCollection<Users> _usersCollection;

    public UserRepository(IConfiguration configuration, IMongoClient mongoClient)
    {
        var dbName = configuration["MongoDBSettings:DatabaseName"];
        var database = mongoClient.GetDatabase(dbName);
        _usersCollection = database.GetCollection<Users>("Users");
    }

    public async Task<List<Users>> GetAllUsersAsync()
    {
        return await _usersCollection.Find(_ => true).ToListAsync();
    }

    public async Task<Users> GetUserByIdAsync(string id)
    {
        return await _usersCollection.Find(user => user.Id == id).FirstOrDefaultAsync();
    }

    public async Task CreateUserAsync(Users user)
    {
        await _usersCollection.InsertOneAsync(user);
    }

    public async Task UpdateUserAsync(string id, Users user)
    {
        await _usersCollection.ReplaceOneAsync(u => u.Id == id, user);
    }

    public async Task DeleteUserAsync(string id)
    {
        await _usersCollection.DeleteOneAsync(u => u.Id == id);
    }
}