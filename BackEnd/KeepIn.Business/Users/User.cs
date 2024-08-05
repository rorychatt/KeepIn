using KeepIn.Business.Contracts;

namespace KeepIn.Business.Users;

public class User : IIdentifiable
{
    public string Id { get; init; } = $"user_{Guid.NewGuid()}";
}