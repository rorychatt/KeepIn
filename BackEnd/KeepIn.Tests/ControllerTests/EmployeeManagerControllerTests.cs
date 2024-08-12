using System.Net;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;

namespace KeepIn.Tests.ControllerTests;

public class EmployeeManagerControllerTests(WebApplicationFactory<Program> factory)
    : IClassFixture<WebApplicationFactory<Program>>
{
    private const string BaseUrl = "/api/EmployeeManager";
    private readonly HttpClient _client = factory.CreateClient();

    [Fact]
    public async Task Should_Return_Employees_When_Get()
    {
        var response = await _client.GetAsync(BaseUrl);

        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
    
    
}