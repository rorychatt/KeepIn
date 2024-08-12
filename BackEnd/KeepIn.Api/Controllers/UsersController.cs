using KeepIn.Api.Models;
using KeepIn.Business.Contracts;
using KeepIn.Business.Core;
using KeepIn.Business.Users;
using Microsoft.AspNetCore.Mvc;

namespace KeepIn.Api.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class UsersController(IUsersRepository usersRepository) : ControllerBase
{
    private readonly IUsersRepository _usersRepository = usersRepository;    

    [HttpGet]
    public ActionResult<IEnumerable<UserResponse>> GetUsers()
    {
        var users = _usersRepository.GetAllUsers();
        return Ok(users.Select(user => new UserResponse(user.Name, user.ActiveModules)));
    }
    
    [HttpGet("{id}")]
    public ActionResult<UserResponse> GetUserById(string id)
    {
        var user = _usersRepository.GetUserById(id);
        if (user is not null)
        {
            return Ok(new UserResponse(user.Name, user.ActiveModules));
        }

        return NotFound();
    }
    
    [HttpGet("name")]
    public ActionResult<UserResponse> GetUserByName([FromQuery] string name)
    {
        var user = _usersRepository.GetUserByName(name);
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
        _usersRepository.AddUser(user);
        return CreatedAtAction(nameof(GetUserById), new { id = user.Id },
            new UserResponse(user.Name, user.ActiveModules));
    }
}