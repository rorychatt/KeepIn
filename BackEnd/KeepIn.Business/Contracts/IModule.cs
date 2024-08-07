using System.Text.Json.Serialization;

namespace KeepIn.Business.Contracts;

public interface IModule : IIdentifiable
{
    public abstract record Properties()
    {
        public required string Name { get; init; }
        public required string Version { get; init; }
        public string? Description { get; init; }
        public string? Author { get; init; }
        public string? License { get; init; }
        public Dictionary<string, string> Dependencies { get; init; } = new();
    }
    
    public record BaseModuleConfigJson()
    {
        [JsonPropertyName("Properties")]
        public Properties? Properties { get; init; }
    }
}