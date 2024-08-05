using KeepIn.Business.Contracts;
using KeepIn.Business.Modules;

namespace KeepIn.Business.Users;

public class User : IUser
{
    public string Id { get; init; } = $"user_{Guid.NewGuid()}";
    public Dictionary<string, IModule> ActiveModules { get; init; } = new();
}