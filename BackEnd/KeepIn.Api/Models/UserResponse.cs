using KeepIn.Business.Contracts;

namespace KeepIn.Api.Models;

public record UserResponse(string Name, IEnumerable<IModule> Modules);