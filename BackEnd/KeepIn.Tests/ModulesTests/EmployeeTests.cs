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
    
}