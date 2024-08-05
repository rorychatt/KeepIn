using KeepIn.Business.Users;

namespace KeepIn.Tests;

public class UserTests
{
    [Fact]
    public void UserShould_HaveUniqueId()
    {
        var user = new User();
        
        Assert.NotEqual("user_", user.Id);
    }

    [Fact]
    public void UserShould_HaveListOfActiveModules()
    {
        var user = new User();
        
        Assert.NotNull(user.ActiveModules);
    }
}