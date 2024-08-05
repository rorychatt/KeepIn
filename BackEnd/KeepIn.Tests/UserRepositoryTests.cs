using KeepIn.Api.Models;
using KeepIn.Business.Users;

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
    
    [Fact]
    public void UserRepositoryShould_CreateUser()
    {
        var userRepository = new UserRepository();
        var user = new User();
        
        Assert.NotNull(userRepository.AddUser(user));
    }
    
    [Fact]
    public void UserRepositoryShould_ReturnUserById()
    {
        var userRepository = new UserRepository();
        var user = new User();
        var createdUser = userRepository.AddUser(user);
        
        Assert.Equal(createdUser, userRepository.GetUserById(createdUser!.Id));
    }
    
    [Fact]
    public void UserRepositoryShould_NotAddUserWithExistingId()
    {
        var userRepository = new UserRepository();
        var user = new User();
        userRepository.AddUser(user);
        
        var badUser = new User { Id = user.Id };
        userRepository.AddUser(badUser);
        
        Assert.Null(userRepository.AddUser(badUser));
    }
}