using FluentAssertions;
using KeepIn.Business.Core;
using KeepIn.Modules.InventoryManager;

namespace KeepIn.Tests;

public class CoreTests
{
    [Fact]
    public void CoreShould_HaveActivatedModules()
    {
        var core = new KeepInCore();

        Assert.NotNull(core.ActivatedModules);
    }
    
    [Fact]
    public void CoreShould_ActivateModule()
    {
        var core = new KeepInCore();
        
        var module = new InventoryManager();
        
        core.ActivateModule(module);
        
        core.ActivatedModules.Should().Contain(module.Properties.Name, module);
    }
    
    [Fact]
    public void CoreShould_DeactivateModule()
    {
        var core = new KeepInCore();
        
        var module = new InventoryManager();
        
        core.ActivateModule(module);
        
        core.DeactivateModule(module);
        
        core.ActivatedModules.Should().NotContain(module.Properties.Name, module);
    }
    
    [Fact]
    public void CoreShould_ThrowException_WhenActivatingAlreadyActivatedModule()
    {
        var core = new KeepInCore();
        
        var module = new InventoryManager();
        
        core.ActivateModule(module);
        
        var act = () => core.ActivateModule(module);
        
        act.Should().Throw<Exception>().WithMessage($"Module {module.Properties.Name} already activated");
    }
    
    [Fact]
    public void CoreShould_ThrowException_WhenDeactivatingNotActivatedModule()
    {
        var core = new KeepInCore();
        
        var module = new InventoryManager();
        
        var act = () => core.DeactivateModule(module);
        
        act.Should().Throw<Exception>().WithMessage($"Module {module.Properties.Name} not activated");
    }
    
    [Fact]
    public void CoreShould_HaveTables()
    {
        var core = new KeepInCore();

        Assert.NotNull(core.Tables);
    }
    
}