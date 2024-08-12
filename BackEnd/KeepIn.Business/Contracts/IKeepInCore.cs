namespace KeepIn.Business.Contracts;

public interface IKeepInCore
{
    public Dictionary<string, IModule> ActivatedModules { get; init; }
    public void ActivateModule(IModule module);
    public void DeactivateModule(IModule module);
    public bool TryInjectTable(
        ITable<string, string[]> table);
}