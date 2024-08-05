using System.Net;
using System.Net.Http.Json;
using KeepIn.Business.Users;
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
    
    [Fact]
    public async Task UsersControllerShould_Return404_ForBadUser()
    {
        var client = factory.CreateClient();
        var response = await client.GetAsync("/users/blob");
        
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
    
    [Fact]
    public async Task UsersControllerShould_CreateUser()
    {
        var client = factory.CreateClient();
        var response = await client.PostAsJsonAsync("/users", "Peter2311");
        
        response.EnsureSuccessStatusCode();
    }
    
    [Fact]
    public async Task UsersControllerShould_ReturnUserById()
    {
        var client = factory.CreateClient();
        var response = await client.PostAsJsonAsync("/users", "Banana12312");
        var createdUser = await response.Content.ReadFromJsonAsync<User>();
        
        var userResponse = await client.GetAsync($"/users/{createdUser!.Id}");
        
        userResponse.EnsureSuccessStatusCode();
    }
    
    // [Fact]
    // public async Task UsersControllerShould_NotAddUserWithExistingId()
    // {
    //     var client = factory.CreateClient();
    //     var response = await client.PostAsJsonAsync("/users", new User());
    //     var createdUser = await response.Content.ReadFromJsonAsync<User>();
    //     
    //     var badUser = new User { Id = createdUser!.Id };
    //     var badResponse = await client.PostAsJsonAsync("/users", badUser);
    //     
    //     Assert.Equal(HttpStatusCode.BadRequest, badResponse.StatusCode);
    // }
}