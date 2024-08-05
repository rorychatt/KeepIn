namespace KeepIn.Business.Contracts;

public interface IModule : IIdentifiable
{
    public record Properties()
    {
        public required string Name { get; init; }
        public required string Version { get; init; }
        public string? Description { get; init; }
        public string? Author { get; init; }
        public string? License { get; init; }
        public Dictionary<string, string> Dependencies { get; init; } = new();
    }
}