using FluentAssertions;
using KeepIn.Business.BaseModule;

namespace KeepIn.Tests;

public class BaseModuleTests
{
    [Fact]
    public void Should_Read_Configuration_File()
    {
        // Arrange
        var module = new BaseModule();
        
        // Act
        var properties = module.Properties;
        
        properties.License.Should().NotBeNull();
        properties.License.Should().Be("MIT");
        properties.Author.Should().NotBeNull();
        properties.Author.Should().Be("KeepIn");
    }
}