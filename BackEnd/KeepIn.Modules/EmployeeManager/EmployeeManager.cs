using KeepIn.Business.BaseModule;

namespace KeepIn.Modules.EmployeeManager;

public class EmployeeManager : BaseModule
{
    public Dictionary<string, Employee> Employees { get; } = [];

    public EmployeeManager()
    {
        var carlEmployee = new Employee()
            .SetName("The best dude ever")
            .SetEmail("carl@gigachad.com")
            .SetAddress("None of your business")
            .SetPhoneNumber("07612311")
            .SetRole(Role.Worker);

        var johnEmployee = new Employee()
            .SetName("John Stevenson")
            .SetEmail("skip@mondays.com")
            .SetAddress("1234 Main St, City, Country")
            .SetPhoneNumber("1234567890")
            .SetRole(Role.Admin);
        
        AddEmployee(carlEmployee);
        AddEmployee(johnEmployee);
    }

    public bool AddEmployee(Employee employee)
    {
        return Employees.TryAdd(employee.Id, employee);
    }

    public bool RemoveEmployee(string employeeId)
    {
        return Employees.Remove(employeeId);
    }

    public Employee? GetEmployeeById(string employeeId)
    {
        return Employees.GetValueOrDefault(employeeId);
    }

    public void UpdateEmployeeRole(string employeeId, Role role)
    {
        Employees[employeeId].SetRole(role);
    }

    public List<Employee> GetEmployees()
    {
        return [.. Employees.Values];
    }
    
}