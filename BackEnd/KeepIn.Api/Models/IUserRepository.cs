using KeepIn.Business.Users;

namespace KeepIn.Api.Models;

public interface IUserRepository
{
    IEnumerable<User> GetAllUsers();
    User? GetUserById(string id);
}