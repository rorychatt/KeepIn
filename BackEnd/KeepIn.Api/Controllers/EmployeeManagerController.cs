using KeepIn.Business.Contracts;
using KeepIn.Modules.EmployeeManager;
using Microsoft.AspNetCore.Mvc;

namespace KeepIn.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeManagerController(IKeepInCore keepInCore) : ControllerBase
{
    private EmployeeManager EmployeeManagerModule { get; init; }
        = (keepInCore.ActivatedModules.TryGetValue("Employee Manager", out var module)
            ? module as EmployeeManager
            : throw new Exception("Employee Manager module not found"))!;

    [HttpGet]
    public ActionResult<IEnumerable<Employee>> GetEmployees()
    {
        Console.WriteLine(keepInCore.ActivatedModules.Keys);
        var employees = EmployeeManagerModule.GetEmployees();
        return Ok(employees);
    }

    [HttpGet("{id}")]
    public ActionResult<Employee> GetEmployeeById(string id)
    {
        var employee = EmployeeManagerModule.GetEmployeeById(id);
        if (employee is not null)
        {
            return Ok(employee);
        }

        return NotFound();
    }
    
}