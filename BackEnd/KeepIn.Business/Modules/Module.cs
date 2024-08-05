using KeepIn.Business.Contracts;

namespace KeepIn.Business.Modules;

public class Module : IModule
{
    public string Id { get; init; } = $"module_{Guid.NewGuid()}";
    public required string Name { get; set; }
    public required string Version { get; set; }
    public string? Description { get; set; }
}