using KeepIn.Business.Contracts;

namespace KeepIn.Modules.EmployeeManager;

public class Employee : IIdentifiable
{
    public string Id { get; init; } = $"employee_{Guid.NewGuid()}";
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Address { get; set; }
    public Role? Role { get; set; } = Modules.EmployeeManager.Role.Guest;
}