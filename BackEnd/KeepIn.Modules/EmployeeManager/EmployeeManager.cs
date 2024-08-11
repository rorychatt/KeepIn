using KeepIn.Business.BaseModule;

namespace KeepIn.Modules.EmployeeManager;

public class EmployeeManager : BaseModule
{
    public readonly Dictionary<string, Employee> Employees = new();
}