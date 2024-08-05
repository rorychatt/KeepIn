using KeepIn.Business.Modules;

namespace KeepIn.Tests;

public class ModuleTests
{
    [Fact]
    public void ModuleShould_HaveUniqueId()
    {
        var module = new Module();
        
        Assert.NotEqual("module_", module.Id);
    }
}