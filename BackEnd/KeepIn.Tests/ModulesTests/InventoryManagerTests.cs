using FluentAssertions;
using KeepIn.Modules.InventoryManager;

namespace KeepIn.Tests.ModulesTests;

public class InventoryManagerTests
{
    [Fact]
    public void InventoryManager_ShouldRead_Config()
    {
        var moduleProperties = new InventoryManager().Properties;
        moduleProperties.Should().NotBeNull();
        moduleProperties.Name.Should().Be("Inventory Manager");
        moduleProperties.Dependencies.Should().NotBeNull();
        moduleProperties.Author.Should().Be("KeepIn");
    }
}