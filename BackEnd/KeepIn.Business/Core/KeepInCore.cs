using KeepIn.Business.Contracts;

namespace KeepIn.Business.Core;

public class KeepInCore : IKeepInCore
{
    public Dictionary<string, IModule> ActivatedModules { get; init; }
    
    public void ActivateModule(IModule module)
    {
        if (!ActivatedModules.TryAdd(module.Properties.Name, module))
        {
            throw new Exception($"Module {module.Properties.Name} already activated");
        }
    }

    public void DeactivateModule(IModule module)
    {
        if (!ActivatedModules.Remove(module.Properties.Name))
        {
            throw new Exception($"Module {module.Properties.Name} not activated");
        }
    }
}