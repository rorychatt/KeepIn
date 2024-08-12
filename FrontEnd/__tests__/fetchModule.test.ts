import {describe, expect, test} from "vitest";
import {addEmployeeAsync, fetchEmployeesAsync, fetchModulesAsync} from "../src/api";
import {Employee} from "../src/ServerTypes";

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
    test("should not crash", async () => {
        const fetchResponse = await fetchEmployeesAsync();
        expect(fetchResponse).toBeDefined();
        const newEmployee: Employee = {
            id: "newed",
            name: "John",
            email: "abracadabra@wow.com",
            phoneNumber: "1234567890",
            address: "1234 Main St",
            role: 1
        }
        const addResponse = await addEmployeeAsync(newEmployee);

        expect(addResponse).toBeDefined();
    });
});

describe("deleteEmployee", () => {
    test("should not crash", async () => {
        const fetchResponse = await fetchEmployeesAsync();
        expect(fetchResponse).toBeDefined();
        const newEmployee: Employee = {
            id: "newed",
            name: "John",
            email: "abracadabra@wow.com",
            phoneNumber: "1234567890",
            address: "1234 Main St",
            role: 1
        }
        const addResponse = await addEmployeeAsync(newEmployee);
        expect(addResponse).toBeDefined();
        const deleteResponse = await fetchEmployeesAsync();
        expect(deleteResponse).toBeDefined();
    });
});