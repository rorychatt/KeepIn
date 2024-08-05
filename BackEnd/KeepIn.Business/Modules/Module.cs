using KeepIn.Business.Contracts;

namespace KeepIn.Business.Modules;

public class Module : IModule
{
    public string Id { get; init; } = $"module_{Guid.NewGuid()}";
}