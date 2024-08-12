using KeepIn.Api.Models;
using KeepIn.Business.Users;

namespace KeepIn.Tests;

public class UsersRepositoryTests
{
    [Fact]
    public void UserRepositoryShould_HaveGetAllUsersMethod()
    {
        var userRepository = new UsersRepository();

        Assert.NotNull(userRepository.GetAllUsers());
    }

    [Fact]
    public void UserRepositoryShould_ReturnNullForNonExistingUser()
    {
        var userRepository = new UsersRepository();

        Assert.Null(userRepository.GetUserById("blob"));
    }

    [Fact]
    public void UserRepositoryShould_CreateUser()
    {
        var userRepository = new UsersRepository();
        var user = new User("Bo1231");

        Assert.NotNull(userRepository.AddUser(user));
    }

    [Fact]
    public void UserRepositoryShould_ReturnUserById()
    {
        var userRepository = new UsersRepository();
        var user = new User("Ba12312");
        var createdUser = userRepository.AddUser(user);

        Assert.Equal(createdUser, userRepository.GetUserById(createdUser!.Id));
    }

    [Fact]
    public void UserRepositoryShould_NotAddUserWithExistingId()
    {
        var userRepository = new UsersRepository();
        var user = new User("kent1231");
        userRepository.AddUser(user);

        var badUser = new User("sa11231") { Id = user.Id };
        userRepository.AddUser(badUser);

        Assert.Null(userRepository.AddUser(badUser));
    }
}