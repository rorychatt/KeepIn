using System.Text.Json.Serialization;

namespace KeepIn.Business.Contracts;

public interface IModule : IIdentifiable
{
    public ModuleProperties Properties { get; }
}

public record ModuleProperties()
{
    public required string Name { get; init; }
    public required string Version { get; init; }
    public string? Description { get; init; }
    public string? Author { get; init; }
    public string? License { get; init; }
    public Dictionary<string, string> Dependencies { get; init; } = new();

    public ModuleProperties(string name, string version) : this()
    {
        Name = name;
        Version = version;
    }
}

public record BaseModuleConfigJson()
{
    [JsonPropertyName("Properties")] public ModuleProperties? Properties { get; init; }
}

