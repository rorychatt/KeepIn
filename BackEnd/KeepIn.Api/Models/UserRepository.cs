using KeepIn.Business.BaseModule;
using KeepIn.Business.Contracts;
using KeepIn.Business.Users;
using KeepIn.Modules.Employees;
using KeepIn.Modules.InventoryManager;

namespace KeepIn.Api.Models;

public class UserRepository : IUserRepository
{
    private readonly Dictionary<string, User> _users = new()
    {
        ["user_default"] = new User("John Stevenson")
        {
            Id = "user_default", ActiveModules = new List<IModule>()
            {
                new InventoryManager(),
                new EmployeeManager(),
                new BaseModule(),
                new BaseModule(),
                new BaseModule(),
                new BaseModule(),
                new BaseModule(),
                new BaseModule(),
                new BaseModule(),
                new BaseModule(),
                new BaseModule(),
                new BaseModule(),
                new BaseModule(),
            }
        }
    };

    public IEnumerable<User> GetAllUsers()
    {
        return _users.Values;
    }

    public User? GetUserById(string id)
    {
        return _users.GetValueOrDefault(id);
    }

    public User? GetUserByName(string name)
    {
        return _users.Values.FirstOrDefault(user => user.Name == name);
    }

    public User? AddUser(User user)
    {
        return !_users.TryAdd(user.Id, user) ? null : user;
    }
}