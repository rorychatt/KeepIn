using KeepIn.Api.Models;
using KeepIn.Business.Users;
using Microsoft.AspNetCore.Mvc;

namespace KeepIn.Api.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class UsersController(IUserRepository userRepository) : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<UserResponse>> GetUsers()
    {
        var users = userRepository.GetAllUsers();
        return Ok(users.Select(user => new UserResponse(user.Name, user.ActiveModules)));
    }
    
    [HttpGet("{id}")]
    public ActionResult<UserResponse> GetUserById(string id)
    {
        var user = userRepository.GetUserById(id);
        if (user is not null)
        {
            return Ok(new UserResponse(user.Name, user.ActiveModules));
        }

        return NotFound();
    }
    
    [HttpGet("name")]
    public ActionResult<UserResponse> GetUserByName([FromQuery] string name)
    {
        var user = userRepository.GetUserByName(name);
        if (user is not null)
        {
            return Ok(new UserResponse(user.Name, user.ActiveModules));
        }

        return NotFound();
    }

    [HttpPost]
    public ActionResult<UserResponse> CreateUser(UserRequest userRequest)
    {
        var user = new User(userRequest.Name);
        userRepository.AddUser(user);
        return CreatedAtAction(nameof(GetUserById), new { id = user.Id },
            new UserResponse(user.Name, user.ActiveModules));
    }
}