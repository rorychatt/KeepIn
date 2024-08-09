using KeepIn.Business.Users;

namespace KeepIn.Tests;

public class DtoTests
{
    [Fact]
    public void UserResponse_ShouldHave_TestUser()
    {
        var user = new User("Petersen");
    }
}