using FluentAssertions;
using KeepIn.Modules.EmployeeManager;

namespace KeepIn.Tests;

public class EmployeeManagerTests
{
    [Fact]
    public void EmployeeManager_ShouldRead_Config()
    {
        var moduleProperties = new EmployeeManager().Properties;
        moduleProperties.Should().NotBeNull();
        moduleProperties.Name.Should().Be("Employee Manager");
        moduleProperties.Dependencies.Should().NotBeNull();
        moduleProperties.Author.Should().Be("KeepIn");
    }
    
    [Fact]
    public void EmployeeManager_ShouldHaveEmployees()
    {
        var employeeManager = new EmployeeManager();
        
        employeeManager.Employees.Should().NotBeNull();
    }
}