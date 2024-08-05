using KeepIn.Business.Contracts;
using KeepIn.Business.Modules;

namespace KeepIn.Business.Users;

public class User(string name) : IUser
{
    public string Id { get; init; } = $"user_{Guid.NewGuid()}";
    public string Name { get; set; } = name;
    public Dictionary<string, IModule> ActiveModules { get; init; } = new();
}