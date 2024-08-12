using KeepIn.Business.Contracts;
using KeepIn.Modules.EmployeeManager;
using Microsoft.AspNetCore.Mvc;

namespace KeepIn.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeManagerController(IKeepInCore keepInCore) : ControllerBase
{
    private IKeepInCore KeepInCore { get; } = keepInCore;

    private EmployeeManager EmployeeManagerModule { get; init; }
        = (keepInCore.ActivatedModules.TryGetValue("EmployeeManager", out var module)
            ? module as EmployeeManager
            : throw new Exception("EmployeeManager module not found"))!;

    [HttpGet]
    public ActionResult<IEnumerable<Employee>> GetEmployees()
    {
        return Ok(EmployeeManagerModule.GetEmployees());
    }
    
}