using KeepIn.Business.BaseModule;
using KeepIn.Business.Contracts;
using KeepIn.Business.Users;
using KeepIn.Modules.EmployeeManager;
using KeepIn.Modules.InventoryManager;

namespace KeepIn.Api.Models;

public class UsersRepository : IUsersRepository
{
    private readonly Dictionary<string, User> _users = [];
    private readonly IKeepInCore _keepInCore;

    public UsersRepository(IKeepInCore keepInCore)
    {
        _keepInCore = keepInCore;
        var newUser = new User("John Stevenson")
        {
            Id = "user_default", ActiveModules =
            [
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
            ]
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
        if (!_users.TryAdd(user.Id, user))
        {
            return null;
        }

        foreach (var module in user.ActiveModules.ToList()
                     .Where(module => !_keepInCore.ActivatedModules.TryGetValue(module.Properties.Name, out _)))
        {
            _keepInCore.ActivateModule(module);
        }

        return user;
    }
}