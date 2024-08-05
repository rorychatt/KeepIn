namespace KeepIn.Business.Contracts;

public interface IUser : IIdentifiable
{
    public Dictionary<string, IModule> ActiveModules { get; init; }
}