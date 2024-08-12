import {AddEmployeeRequest, Employee, ServerEmployeesResponse, ServerUserResponse} from "./ServerTypes.ts";

export async function fetchModulesAsync(): Promise<ServerUserResponse> {
    try {
        const response = await fetch("http://localhost:5126/api/Users/name?name=John%20Stevenson");
        if (!response.ok) {
            console.warn("Failed to fetch modules");
            return MOCK_SERVER_USER_RESPONSE;
        }
        return response.json();
    } catch (error) {
        console.error("Error fetching modules:", error);
        return MOCK_SERVER_USER_RESPONSE;
    }
}

export async function fetchEmployeesAsync(): Promise<ServerEmployeesResponse> {
    try {
        const response = await fetch("http://localhost:5126/api/EmployeeManager");
        if (!response.ok) {
            console.warn("Failed to fetch employees");
            return MOCK_SERVER_EMPLOYEES_RESPONSE;
        }
        return response.json();
    } catch (error) {
        console.error("Error fetching employees:", error);
        return MOCK_SERVER_EMPLOYEES_RESPONSE;
    }
}

export async function addEmployeeAsync(addEmployeeRequest: AddEmployeeRequest): Promise<Employee> {

    const response = await fetch('http://localhost:5126/api/EmployeeManager', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(addEmployeeRequest),
    });
    if (!response.ok) {
        throw new Error('Failed to add employee');
    }
    return response.json();
}

export async function updateEmployeeAsync(employee: Employee): Promise<Employee> {
    const response = await fetch(`http://localhost:5126/api/EmployeeManager/${employee.id}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(employee),
    });
    if (!response.ok) {
        throw new Error('Failed to update employee');
    }
    return response.json();
}

export async function deleteEmployeeAsync(employeeId: string): Promise<void> {
    const response = await fetch(`http://localhost:5126/api/EmployeeManager/${employeeId}`, {
        method: 'DELETE',
    });
    if (!response.ok) {
        throw new Error('Failed to delete employee');
    }
}

export const MOCK_SERVER_EMPLOYEES_RESPONSE: ServerEmployeesResponse = [
    {
        "id": "employee_e5fff2f8-4969-4bb0-8012-ea85202c0bca",
        "name": "The best dude ever",
        "email": "carl@gigachad.com",
        "phoneNumber": "07612311",
        "address": "None of your business",
        "role": 1
    },
    {
        "id": "employee_55dd98de-82fc-4ac6-bdd4-7033975da514",
        "name": "John Stevenson",
        "email": "skip@mondays.com",
        "phoneNumber": "1234567890",
        "address": "1234 Main St, City, Country",
        "role": 3
    }
]

export const MOCK_SERVER_USER_RESPONSE: ServerUserResponse = {
    "name": "John Stevenson",
    "modules": [
        {
            "properties": {
                "name": "Inventory Manager",
                "version": "1.0.0",
                "description": "Base module for KeepIn",
                "author": "KeepIn",
                "license": "MIT",
                "dependencies": {
                    "BaseModule": "1.0.0"
                }
            },
            "id": "module_9184eafe-335c-457a-a9f3-5b06a2bfc2ec"
        },
        {
            "properties": {
                "name": "Employee Manager",
                "version": "1.0.0",
                "description": "Base module for KeepIn",
                "author": "KeepIn",
                "license": "MIT",
                "dependencies": {
                    "BaseModule": "1.0.0"
                }
            },
            "id": "module_21769838-e3af-4784-a31f-9e9f5b508c55"
        },
        {
            "properties": {
                "name": "BaseModule",
                "version": "1.0.0",
                "description": "Base module for KeepIn",
                "author": "KeepIn",
                "license": "MIT",
                "dependencies": {}
            },
            "id": "module_ffb172c7-45e5-4d5a-ad15-3fea25d50795"
        },
        {
            "properties": {
                "name": "BaseModule",
                "version": "1.0.0",
                "description": "Base module for KeepIn",
                "author": "KeepIn",
                "license": "MIT",
                "dependencies": {}
            },
            "id": "module_0d3eb9f3-7dc4-4652-b5af-3444a395c75d"
        },
        {
            "properties": {
                "name": "BaseModule",
                "version": "1.0.0",
                "description": "Base module for KeepIn",
                "author": "KeepIn",
                "license": "MIT",
                "dependencies": {}
            },
            "id": "module_73fdd1b1-13f7-410b-8141-5c977b8674fa"
        },
        {
            "properties": {
                "name": "BaseModule",
                "version": "1.0.0",
                "description": "Base module for KeepIn",
                "author": "KeepIn",
                "license": "MIT",
                "dependencies": {}
            },
            "id": "module_fc5606a1-ae43-466f-acca-93bf931ccb65"
        },
        {
            "properties": {
                "name": "BaseModule",
                "version": "1.0.0",
                "description": "Base module for KeepIn",
                "author": "KeepIn",
                "license": "MIT",
                "dependencies": {}
            },
            "id": "module_013ce262-e48e-4f8b-9366-170433c905ee"
        },
        {
            "properties": {
                "name": "BaseModule",
                "version": "1.0.0",
                "description": "Base module for KeepIn",
                "author": "KeepIn",
                "license": "MIT",
                "dependencies": {}
            },
            "id": "module_025bc23a-f119-4ac6-a3ae-ef2b8e4185fe"
        },
        {
            "properties": {
                "name": "BaseModule",
                "version": "1.0.0",
                "description": "Base module for KeepIn",
                "author": "KeepIn",
                "license": "MIT",
                "dependencies": {}
            },
            "id": "module_99aebaea-345c-4f54-919d-f6c433fa9552"
        },
        {
            "properties": {
                "name": "BaseModule",
                "version": "1.0.0",
                "description": "Base module for KeepIn",
                "author": "KeepIn",
                "license": "MIT",
                "dependencies": {}
            },
            "id": "module_fc943cca-b7fc-403e-9c8c-c48190efe4fb"
        },
        {
            "properties": {
                "name": "BaseModule",
                "version": "1.0.0",
                "description": "Base module for KeepIn",
                "author": "KeepIn",
                "license": "MIT",
                "dependencies": {}
            },
            "id": "module_04f857d3-cced-4662-8721-9995438a3f6e"
        },
        {
            "properties": {
                "name": "BaseModule",
                "version": "1.0.0",
                "description": "Base module for KeepIn",
                "author": "KeepIn",
                "license": "MIT",
                "dependencies": {}
            },
            "id": "module_35719d2e-eca9-4448-b671-dee023aa9f52"
        },
        {
            "properties": {
                "name": "BaseModule",
                "version": "1.0.0",
                "description": "Base module for KeepIn",
                "author": "KeepIn",
                "license": "MIT",
                "dependencies": {}
            },
            "id": "module_9dd28cd3-d8d5-4ca7-929e-ce4688d38f23"
        }
    ]
};
