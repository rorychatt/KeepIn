using FluentAssertions;
using KeepIn.Business.Users;
using KeepIn.Modules.InventoryManager;

namespace KeepIn.Tests;

public class UserTests
{
    [Fact]
    public void UserShould_HaveUniqueId()
    {
        var user = new User("kENT2231");

        Assert.NotEqual("user_", user.Id);
    }

    [Fact]
    public void UserShould_HaveListOfActiveModules()
    {
        var user = new User("Wekt1221");

        Assert.NotNull(user.ActiveModules);
    }

    [Fact]
    public void UserShould_RegisterNewModule()
    {
        var user = new User("Peterson");

        var moduleCountBefore = user.ActiveModules.Count();

        user.RegisterNewModule(new InventoryManager());

        var moduleCountAfter = user.ActiveModules.Count();

        Assert.Equal(moduleCountBefore + 1, moduleCountAfter);
    }

    [Fact]
    public void UserShould_HaveGetModuleByName_Working()
    {
        var user = new User("Peterson");
    
        var addedModule = user.RegisterNewModule(new InventoryManager())!;
    
        var foundModule = user.GetModuleByName(addedModule.Properties.Name);
    
        foundModule.Should().NotBeNull();
        foundModule.Properties.Name.Should().Be(addedModule.Properties.Name);
    }

    [Fact]
    public void User_RegisterNewModule_RegistersNewModule()
    {
        var user = new User("PetersonV2");
        
        var addedModule = user.RegisterNewModule(new InventoryManager())!;
        
        user.ActiveModules.Should().Contain(addedModule);
        
        addedModule.Properties.Name.Should().Be("Inventory Manager");
        addedModule.Properties.License.Should().Be("MIT");
    }
}