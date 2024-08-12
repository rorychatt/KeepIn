import {describe, expect, test} from "vitest";
import {addEmployeeAsync, fetchEmployeesAsync, fetchModulesAsync, updateEmployeeAsync} from "../src/api";
import {AddEmployeeRequest, Employee, RoleEnum} from "../src/ServerTypes";

describe("fetchModules", () => {
    test("should not crash", async () => {
        const response = await fetchModulesAsync();
        expect(response).toBeDefined();
    })

    test("should return an array", async () => {
        const response = await fetchModulesAsync();
        expect(Array.isArray(response.modules)).toBe(true);
    })
})

describe("fetchEmployees", () => {
    test("should not crash", async () => {
        const response = await fetchEmployeesAsync();
        expect(response).toBeDefined();
    })

    test("should return an array", async () => {
        const response = await fetchEmployeesAsync();
        expect(Array.isArray(response)).toBe(true);
    })
});

describe("addEmployee", () => {
    test("should not crash and add", async () => {
        const fetchResponse = await fetchEmployeesAsync();
        expect(fetchResponse).toBeDefined();
        const newEmployee: AddEmployeeRequest = {
            Name: "John",
            Email: "abracadabra@wow.com",
            PhoneNumber: "1234567890",
            Address: "1234 Main St",
            Role: RoleEnum.Manager
        }
        const addResponse = await addEmployeeAsync(newEmployee);

        expect(addResponse).toBeDefined();
    });

});

describe("deleteEmployee", () => {
    test("should not crash and delete", async () => {
        const fetchResponse = await fetchEmployeesAsync();
        expect(fetchResponse).toBeDefined();
        const newEmployee: AddEmployeeRequest = {
            Name: "John",
            Email: "abracadabra@wow.com",
            PhoneNumber: "1234567890",
            Address: "1234 Main St",
            Role: RoleEnum.Worker
        }
        const addResponse = await addEmployeeAsync(newEmployee);
        expect(addResponse).toBeDefined();
        const deleteResponse = await fetchEmployeesAsync();
        expect(deleteResponse).toBeDefined();
    });
});

describe("updateEmployee", () => {
    test("should not crash and update", async () => {
        const fetchResponse = await fetchEmployeesAsync();
        expect(fetchResponse).toBeDefined();
        const employeeToUpdate = fetchResponse[0];
        const newEmployee: Employee = {
            id: employeeToUpdate.id,
            name: "Peter",
            email: "ahaa@gmail.com",
            phoneNumber: "0987654321",
            address: "4321 Main St haha",
            role: RoleEnum.Admin
        }
        const updateResponse = await updateEmployeeAsync(newEmployee)
        expect(updateResponse).toBeDefined();

        expect(updateResponse.address).toBe(newEmployee.address);
    });
});