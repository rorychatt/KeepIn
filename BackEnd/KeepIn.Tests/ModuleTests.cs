using KeepIn.Business.Modules;

namespace KeepIn.Tests;

public class ModuleTests
{
    [Fact]
    public void ModuleShould_HaveUniqueId()
    {
        var module = new Module
        {
            Name = "Test",
            Version = "1.0.0"
        };
        
        Assert.NotEqual("module_", module.Id);
    }
}