using KeepIn.Api.Models;

namespace KeepIn.Tests;

public class UserRepositoryTests
{
    [Fact]
    public void UserRepositoryShould_HaveGetAllUsersMethod()
    {
        var userRepository = new UserRepository();
        
        Assert.NotNull(userRepository.GetAllUsers());
    }
}