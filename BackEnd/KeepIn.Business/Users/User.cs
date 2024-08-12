using KeepIn.Business.Contracts;

namespace KeepIn.Business.Users;

public class User(string name) : IUser
{
    public string Id { get; init; } = $"user_{Guid.NewGuid()}";
    public string Name { get; set; } = name;

    public IEnumerable<IModule> ActiveModules
    {
        get => _activeModules;
        set => _activeModules = value.ToList();
    }

    private List<IModule> _activeModules = [];

    public IModule? RegisterNewModule(IModule module)
    {
        //Todo: this is super fishy... we should not be able to register the same module twice
        _activeModules.Add(module);
        return module;
    }

    public IModule? GetModuleByName(string moduleName)
    {
        return _activeModules.FirstOrDefault(m => m.Properties.Name == moduleName);
    }
}