using Microsoft.AspNetCore.Mvc.Testing;

namespace KeepIn.Tests;

public class UsersControllerTests(WebApplicationFactory<Program> factory)
    : IClassFixture<WebApplicationFactory<Program>>
{
    [Fact]
    public async Task UsersControllerShould_ReturnListOfUsers()
    {
        var client = factory.CreateClient();
        var response = await client.GetAsync("/users");

        response.EnsureSuccessStatusCode();
    }
}