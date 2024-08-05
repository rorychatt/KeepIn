namespace KeepIn.Business.Contracts;

public interface IModule : IIdentifiable
{
    string Name { get; set; }
    string Version { get; set; }
    string? Description { get; set; }
}