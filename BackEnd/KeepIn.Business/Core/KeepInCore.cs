using KeepIn.Business.Contracts;

namespace KeepIn.Business.Core;

public class KeepInCore : IKeepInCore
{
    public Dictionary<string, IModule> ActivatedModules { get; init; } = new();
    public Dictionary<string, ITable<string, string[]>> Tables { get; init; } = new();

    public void ActivateModule(IModule module)
    {
        //TODO: better handling here
        Console.WriteLine(!ActivatedModules.TryAdd(module.Properties.Name, module)
            ? $"Module {module.Properties.Name} already activated"
            : $"Module {module.Properties.Name} activated");
    }

    public void DeactivateModule(IModule module)
    {
        if (!ActivatedModules.Remove(module.Properties.Name))
        {
            throw new Exception($"Module {module.Properties.Name} not activated");
        }
        else
        {
            Console.WriteLine($"Module {module.Properties.Name} deactivated");;
        }
    }

    public bool TryInjectTable(ITable<string, string[]> table)
    {
        return Tables.TryAdd(table.TableName, table);
    }
}