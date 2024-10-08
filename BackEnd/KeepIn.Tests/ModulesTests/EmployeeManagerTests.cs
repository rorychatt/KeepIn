﻿using FluentAssertions;
using KeepIn.Modules.EmployeeManager;

namespace KeepIn.Tests.ModulesTests;

public class EmployeeManagerTests
{
    [Fact]
    public void EmployeeManager_ShouldRead_Config()
    {
        var moduleProperties = new EmployeeManager().Properties;
        moduleProperties.Should().NotBeNull();
        moduleProperties.Name.Should().Be("Employee Manager");
        moduleProperties.Dependencies.Should().NotBeNull();
        moduleProperties.Author.Should().Be("KeepIn");
    }

    [Fact]
    public void EmployeeManager_ShouldHaveEmployees()
    {
        var employeeManager = new EmployeeManager();

        employeeManager.Employees.Should().NotBeNull();
    }

    [Fact]
    public void EmployeeManager_ShouldAddEmployee()
    {
        var employee = new Employee();
        var employeeManager = new EmployeeManager();

        employeeManager.AddEmployee(employee).Should().NotBe(false);
    }

    [Fact]
    public void EmployeeManager_ShouldRemoveEmployee()
    {
        var employee = new Employee();
        var employeeManager = new EmployeeManager();

        employeeManager.AddEmployee(employee);
        employeeManager.RemoveEmployee(employee.Id).Should().Be(true);
    }

    [Fact]
    public void EmployeeManager_ShouldNotRemoveWrongEmployee()
    {
        var employee = new Employee();
        var employeeManager = new EmployeeManager();

        employeeManager.AddEmployee(employee);
        employeeManager.RemoveEmployee("invalidId").Should().Be(false);
    }

    [Fact]
    public void EmployeeManager_ShouldGetEmployee()
    {
        var employee = new Employee();
        var employeeManager = new EmployeeManager();

        employeeManager.AddEmployee(employee);
        employeeManager.GetEmployeeById(employee.Id).Should().Be(employee);
    }

    [Fact]
    public void EmployeeManager_ShouldNotGetWrongEmployee()
    {
        var employee = new Employee();
        var employeeManager = new EmployeeManager();

        employeeManager.AddEmployee(employee);
        employeeManager.GetEmployeeById("invalidId").Should().BeNull();
    }

    [Fact]
    public void EmployeeManager_ShouldUpdateEmployee()
    {
        var employee = new Employee();
        var employeeManager = new EmployeeManager();

        employeeManager.AddEmployee(employee);
        employeeManager.UpdateEmployee(employee.Id, new Employee().SetRole(Role.Admin));
        
        employeeManager.GetEmployeeById(employee.Id)!.Role.Should().Be(Role.Admin);
    }
}