using KeepIn.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace KeepIn.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        if (request is { Username: "admin", Password: "password" })
        {
            return Ok();
        }

        return Unauthorized();
    }
}