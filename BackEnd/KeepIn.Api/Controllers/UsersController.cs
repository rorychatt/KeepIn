using KeepIn.Api.Models;
using KeepIn.Business.Users;
using Microsoft.AspNetCore.Mvc;

namespace KeepIn.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController(IUserRepository userRepository) : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<UserResponse>> GetAll()
    {
        return Ok(userRepository.GetAllUsers().Select(u => new UserResponse(u.Name, u.ActiveModules.Values)));
    }

    [HttpGet("{id}")]
    public ActionResult<UserResponse> GetUserById(string id)
    {
        var user = userRepository.GetUserById(id);
        if (user is null)
        {
            return NotFound();
        }

        return Ok(new UserResponse(user.Name, user.ActiveModules.Values));
    }
    
    [HttpPost]
    public ActionResult<UserResponse> Post([FromBody] UserRequest userRequest)
    {
        var user = new User(userRequest.Id);
        var createdUser = userRepository.AddUser(user);
        if (createdUser is null)
        {
            return BadRequest();
        }

        return CreatedAtAction(nameof(GetUserById), new { id = createdUser!.Id }, new UserResponse(createdUser.Name, createdUser.ActiveModules.Values));
    }
}