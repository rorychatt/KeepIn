using KeepIn.Business.Contracts;

namespace KeepIn.Business.Core;

public class KeepInCore : IKeepInCore
{
    public Dictionary<string, IModule> ActivatedModules { get; init; } = new();
    public Dictionary<string, ITable<string, string[]>> Tables { get; init; } = new();

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

    public bool TryInjectTable(ITable<string, string[]> table)
    {
        return Tables.TryAdd(table.TableName, table);
    }
}