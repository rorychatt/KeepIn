using KeepIn.Api.Models;
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

    [HttpPost]
    public ActionResult<Employee> AddEmployee([FromBody] AddEmployeeRequest addEmployeeRequest)
    {
        var employee = (Employee)addEmployeeRequest;
        var addedEmployee = EmployeeManagerModule.AddEmployee(employee);
        if (addedEmployee)
        {
            return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Id }, employee);
        }
        return Conflict("Employee could not be added due to a conflict.");
    }

    [HttpPut("{id}")]
    public ActionResult<Employee> UpdateEmployee(string id, Employee employee)
    {
        var updatedEmployee = EmployeeManagerModule.UpdateEmployee(id, employee);
        if (updatedEmployee is not null)
        {
            return Ok(updatedEmployee);
        }

        return NotFound();
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteEmployee(string id)
    {
        var deleted = EmployeeManagerModule.DeleteEmployee(id);
        if (deleted)
        {
            return Ok();
        }

        return NotFound();
    }
}