using KeepIn.Business.BaseModule;

namespace KeepIn.Modules.EmployeeManager;

public class EmployeeManager : BaseModule
{
    public Dictionary<string, Employee> Employees { get; } = new();

    public bool AddEmployee(Employee employee)
    {
        return Employees.TryAdd(employee.Id, employee);
    }

    // public void RemoveEmployee(string employeeId)
    // {
    //     Employees.Remove(employeeId);
    // }
    //
    // public Employee GetEmployee(string employeeId)
    // {
    //     return Employees[employeeId];
    // }
    //
    // public void UpdateEmployeeRole(string employeeId, Role role)
    // {
    //     Employees[employeeId].SetRole(role);
    // }
}