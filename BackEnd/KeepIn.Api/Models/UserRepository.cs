using KeepIn.Business.Users;

namespace KeepIn.Api.Models;

public class UserRepository : IUserRepository
{
    private readonly Dictionary<string, User> _users = new();
    public IEnumerable<User> GetAllUsers()
    {
        return _users.Values;
    }

    public User? GetUserById(string id)
    {
        return _users.GetValueOrDefault(id);
    }
}