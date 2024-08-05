namespace KeepIn.Business.Contracts;

public interface IModule : IIdentifiable
{
    public abstract record Properties()
    {
        public required string Name { get; init; }
        public required string Version { get; init; }
        private string? Description { get; init; }
        private string? Author { get; init; }
        private string? License { get; init; }
        public required Dictionary<string, string> Dependencies { get; init; }
    }
    public abstract Dictionary<string, string> Dependencies { get; init; }
}