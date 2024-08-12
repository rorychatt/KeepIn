using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using KeepIn.Api.Models;
using KeepIn.Modules.EmployeeManager;
using Microsoft.AspNetCore.Mvc.Testing;

namespace KeepIn.Tests.ControllerTests;

public class EmployeeManagerControllerTests(WebApplicationFactory<Program> factory)
    : IClassFixture<WebApplicationFactory<Program>>
{
    private const string BaseUrl = "/api/EmployeeManager";
    private readonly HttpClient _client = factory.CreateClient();

    [Fact]
    public void AddEmployeeRequest_ShouldConvert()
    {
        var addEmployeeRequest = new AddEmployeeRequest("aaa", "bbb", "111", "222", Role.Manager);

        var employee = (Employee)addEmployeeRequest;

        employee.Name.Should().Be("aaa");
        employee.Email.Should().Be("bbb");
        employee.PhoneNumber.Should().Be("111");
        employee.Address.Should().Be("222");
        employee.Role.Should().Be(Role.Manager);
    }

    [Fact]
    public async Task Should_Return_Employees_When_Get()
    {
        var response = await _client.GetAsync(BaseUrl);

        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task Should_Add_Employee()
    {
        var employee = new Employee
        {
            Name = "John Doe",
            Email = "John_doe@gmail.com",
            PhoneNumber = "123456789",
            Address = "1234 Main St, City, Country",
            Role = Role.Admin
        };

        var response = await _client.PostAsJsonAsync(BaseUrl, employee);

        response.StatusCode.Should().Be(HttpStatusCode.Created);
    }
}