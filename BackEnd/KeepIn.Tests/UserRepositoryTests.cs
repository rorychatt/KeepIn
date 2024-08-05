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
    
    [Fact]
    public void UserRepositoryShould_ReturnNullForNonExistingUser()
    {
        var userRepository = new UserRepository();
        
        Assert.Null(userRepository.GetUserById("blob"));
    }
}