using System.Net;
using System.Text;
using FluentAssertions;
using KeepIn.Api.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace KeepIn.Tests.ControllerTests;

public class UsersControllerTests(WebApplicationFactory<Program> factory)
    : IClassFixture<WebApplicationFactory<Program>>
{
    private const string BaseUrl = "/api/Users";
    private readonly HttpClient _client = factory.CreateClient();

    private async Task<HttpResponseMessage> CreateUser(string name) => await _client.PostAsync(BaseUrl,
        new StringContent(JsonSerializer.Serialize(new UserRequest(name)), Encoding.UTF8, "application/json"));

    [Fact]
    public async Task Should_CreateNewUser_When_Post()
    {
        var response = await CreateUser("Peter321");

        response.StatusCode.Should().Be(HttpStatusCode.Created);
    }

    [Fact]
    public async Task Should_Return_NewUser_From_CreateUser()
    {
        var response = await CreateUser("asd123as000");

        var userResponse = JsonConvert.DeserializeObject<UserResponse>(await response.Content.ReadAsStringAsync());

        userResponse?.Name.Should().Be("asd123as000");
    }

    [Fact]
    public async Task Should_Return_User_When_GetById()
    {
        const string expectedName = "gobus121";
        var createUserResponse = await CreateUser(expectedName);
        var userResponseRouteValue = createUserResponse.Headers.Location?.ToString().Split('/').Last();

        var getUserResponse = await _client.GetAsync($"{BaseUrl}/{userResponseRouteValue}");

        var userResponse =
            JsonConvert.DeserializeObject<UserResponse>(await getUserResponse.Content.ReadAsStringAsync());

        userResponse?.Name.Should().Be(expectedName);
    }
    
    [Fact]
    public async Task Should_Return_User_When_GetByName()
    {
        const string expectedName = "gobus1212";
        await CreateUser(expectedName);

        var getUserResponse = await _client.GetAsync($"{BaseUrl}/name?name={expectedName}");

        var userResponse =
            JsonConvert.DeserializeObject<UserResponse>(await getUserResponse.Content.ReadAsStringAsync());

        userResponse?.Name.Should().Be(expectedName);
    }
}