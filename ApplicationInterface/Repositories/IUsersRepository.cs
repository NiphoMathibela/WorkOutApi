public interface IUsersRepository
{
    Task<List<Users>> GetAllUsersAsync();
    Task<Users> GetUserByIdAsync(string id);
    Task CreateUserAsync(Users user);
    Task UpdateUserAsync(string id, Users user);
    Task DeleteUserAsync(string id);
}