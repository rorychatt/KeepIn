using FluentAssertions;
using KeepIn.Modules.EmployeeManager;

namespace KeepIn.Tests.ModulesTests;

public class EmployeeTests
{
    [Fact]
    public void Employee_ShouldHaveId()
    {
        var employee = new Employee();
        
        employee.Id.Should().NotBeNullOrEmpty();
    }
    
    [Fact]
    public void Employee_ShouldHaveName()
    {
        var employee = new Employee();
        
        employee.SetName("John Doe");
        
        employee.Name.Should().Be("John Doe");
    }

    [Fact]
    public void Employee_ShouldHaveEmail()
    {
        var employee = new Employee();

        employee.SetEmail("asda@gmail.com");

        employee.Email.Should().Be("asda@gmail.com");

    }

    [Fact]
    public void Employee_ShouldHavePhoneNumber()
    {
        var employee = new Employee();

        employee.SetPhoneNumber("1234567890");

        employee.PhoneNumber.Should().Be("1234567890");
    }
    
    [Fact]
    public void Employee_ShouldHaveAddress()
    {
        var employee = new Employee();
        
        employee.SetAddress("1234 Main St, City, Country");
        
        employee.Address.Should().Be("1234 Main St, City, Country");
    }
    
    [Fact]
    public void Employee_ShouldHaveRole()
    {
        var employee = new Employee();
        
        employee.SetRole(Role.Admin);
        
        employee.Role.Should().Be(Role.Admin);
    }

    [Fact]
    public void Employee_ShouldChainMethods()
    {
        var employee = new Employee();

        employee
            .SetName("John Doe")
            .SetEmail("aha@gmail.com")
            .SetRole(Role.Manager)
            .SetPhoneNumber("1234567890");
        
        employee.Name.Should().Be("John Doe");
        employee.Email.Should().Be("aha@gmail.com");
        employee.Role.Should().Be(Role.Manager);
        employee.PhoneNumber.Should().Be("1234567890");

    }

}