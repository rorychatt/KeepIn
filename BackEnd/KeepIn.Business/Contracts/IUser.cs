namespace KeepIn.Business.Contracts;

public interface IUser : IIdentifiable
{
    public IEnumerable<IModule> ActiveModules { get; set; }
    public IModule? RegisterNewModule(IModule module);
    public IModule? GetModuleByName(string moduleName);
}