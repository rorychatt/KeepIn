
import {Module, Employee, RoleEnum} from "../../ServerTypes.ts";
import { fetchEmployeesAsync } from "../../api.ts";
import React, {useEffect, useState} from "react";

function EmployeesTable() {
    const [employees, setEmployees] = useState<Employee[]>([]);
    const [newEmployee, setNewEmployee] = useState<Employee>({
        id: '',
        name: '',
        email: '',
        phoneNumber: '',
        address: '',
        role: RoleEnum.Guest,
    });

    useEffect(() => {
        fetchEmployeesAsync()
            .then(setEmployees)
            .catch(error => console.error('Error fetching employees:', error));
    }, []);

    const handleInputChange = (e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>) => {
        const { name, value } = e.target;
        setNewEmployee(prevState => ({
            ...prevState,
            [name]: value,
        }));
    };

    const handleAddEmployee = () => {
        setEmployees(prevEmployees => [
            ...prevEmployees,
            { ...newEmployee, id: (prevEmployees.length + 1).toString() },
        ]);
        setNewEmployee({
            id: '',
            name: '',
            email: '',
            phoneNumber: '',
            address: '',
            role: RoleEnum.Guest,
        });
    };

    return (
        <div className="overflow-x-auto">
            <table className="min-w-full bg-white border border-gray-200">
                <thead>
                <tr className="bg-gray-100 border-b">
                    <th className="py-2 px-4 text-left">Name</th>
                    <th className="py-2 px-4 text-left">Email</th>
                    <th className="py-2 px-4 text-left">Phone Number</th>
                    <th className="py-2 px-4 text-left">Address</th>
                    <th className="py-2 px-4 text-left">Role</th>
                </tr>
                </thead>
                <tbody>
                {employees.map(employee => (
                    <tr key={employee.id} className="border-b hover:bg-gray-50">
                        <td className="py-2 px-4">{employee.name}</td>
                        <td className="py-2 px-4">{employee.email}</td>
                        <td className="py-2 px-4">{employee.phoneNumber}</td>
                        <td className="py-2 px-4">{employee.address}</td>
                        <td className="py-2 px-4">{RoleEnum[employee.role]}</td>
                    </tr>
                ))}
                </tbody>
            </table>
            <div className="mt-4">
                <h3 className="text-xl mb-2">Add New Employee</h3>
                <input
                    type="text"
                    name="name"
                    placeholder="Name"
                    value={newEmployee.name}
                    onChange={handleInputChange}
                    className="mb-2 p-2 border rounded w-full"
                />
                <input
                    type="email"
                    name="email"
                    placeholder="Email"
                    value={newEmployee.email}
                    onChange={handleInputChange}
                    className="mb-2 p-2 border rounded w-full"
                />
                <input
                    type="text"
                    name="phoneNumber"
                    placeholder="Phone Number"
                    value={newEmployee.phoneNumber}
                    onChange={handleInputChange}
                    className="mb-2 p-2 border rounded w-full"
                />
                <input
                    type="text"
                    name="address"
                    placeholder="Address"
                    value={newEmployee.address}
                    onChange={handleInputChange}
                    className="mb-2 p-2 border rounded w-full"
                />
                <select
                    name="role"
                    value={newEmployee.role}
                    onChange={handleInputChange}
                    className="mb-2 p-2 border rounded w-full"
                >
                    {Object.keys(RoleEnum)
                        .filter(key => isNaN(Number(key)))
                        .map(key => (
                            <option key={key} value={RoleEnum[key as keyof typeof RoleEnum]}>
                                {key}
                            </option>
                        ))}
                </select>
                <button onClick={handleAddEmployee} className="bg-blue-500 text-white p-2 rounded w-full">
                    Add Employee
                </button>
            </div>
        </div>
    );
}
const EmployeeManagerMain = ({module}: { module: Module }) => {
    return <div>
        <h2 className="text-2xl font-bold mb-4">{module.properties.name}</h2>
        <p>{module.properties.description}</p>
        <EmployeesTable/>
    </div>
}

export default EmployeeManagerMain