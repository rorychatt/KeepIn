using KeepIn.Business.BaseModule;
using KeepIn.Business.Contracts;
using KeepIn.Business.Users;
using KeepIn.Modules.EmployeeManager;
using KeepIn.Modules.InventoryManager;

namespace KeepIn.Api.Models;

public class UsersRepository() : IUserRepository
{
    private readonly Dictionary<string, User> _users = new();
    private readonly IKeepInCore _keepInCore = null!;
    
    public UsersRepository(IKeepInCore keepInCore) : this()
    {
        _keepInCore = keepInCore;
        var newUser = new User("John Stevenson")
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
        };
        AddUser(newUser);
    }
    

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
        foreach (var module in user.ActiveModules)
        {
            _keepInCore.ActivateModule(module);
        }
        return !_users.TryAdd(user.Id, user) ? null : user;
    }
}