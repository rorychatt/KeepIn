using KeepIn.Api.Models;
using KeepIn.Business.Users;
using Microsoft.AspNetCore.Mvc;

namespace KeepIn.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    
    private readonly IUserRepository _userRepository = new UserRepository();
    
    [HttpGet]
    public ActionResult<List<User>> GetAllUsers()
    {
        return Ok(_userRepository.GetAllUsers());
    }
}