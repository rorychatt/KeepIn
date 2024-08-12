using KeepIn.Business.Contracts;

namespace KeepIn.Modules.EmployeeManager;

public class Employee(string? id = null) : IIdentifiable
{
    public string Id { get; init; } = id ?? $"employee_{Guid.NewGuid()}";
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Address { get; set; }
    public Role? Role { get; set; } = Modules.EmployeeManager.Role.Guest;

    public Employee SetName(string name)
    {
        Name = name;
        return this;
    }
    
    public Employee SetEmail(string email)
    {
        Email = email;
        return this;
    }
    
    public Employee SetPhoneNumber(string phoneNumber)
    {
        PhoneNumber = phoneNumber;
        return this;
    }
    
    public Employee SetAddress(string address)
    {
        Address = address;
        return this;
    }
    
    public Employee SetRole(Role role)
    {
        Role = role;
        return this;
    }
    
}