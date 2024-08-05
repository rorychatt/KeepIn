namespace KeepIn.Business.Contracts;

public interface IUser : IIdentifiable
{
    public IEnumerable<IModule> ActiveModules { get; init; }
}