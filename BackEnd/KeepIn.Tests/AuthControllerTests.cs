using System.Net;
using System.Text;
using System.Text.Json;
using FluentAssertions;
using KeepIn.Api.Models;
using Microsoft.AspNetCore.Mvc.Testing;

namespace KeepIn.Tests;

public class AuthControllerTests(WebApplicationFactory<Program> factory)
    : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client = factory.CreateClient();

    [Fact]
    public async Task Should_ReturnOk_When_LoginWithAdmin()
    {
        var response = await _client.PostAsync("/api/Auth/login",
            new StringContent(JsonSerializer.Serialize(
                    new LoginRequest("admin", "password")),
                Encoding.UTF8, "application/json"
            ));

        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}