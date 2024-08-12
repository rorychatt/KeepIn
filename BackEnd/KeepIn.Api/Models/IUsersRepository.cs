using KeepIn.Business.Users;

namespace KeepIn.Api.Models;

public interface IUsersRepository
{
    IEnumerable<User> GetAllUsers();
    User? GetUserById(string id);
    User? GetUserByName(string name);
    User? AddUser(User user);
}