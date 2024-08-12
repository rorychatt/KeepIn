
import {Module, Employee, RoleEnum} from "../../ServerTypes.ts";
import {addEmployeeAsync, deleteEmployeeAsync, fetchEmployeesAsync, updateEmployeeAsync} from "../../api.ts";
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
    const [isEditing, setIsEditing] = useState<boolean>(false);

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

    const handleAddEmployee = async () => {
        try {
            const addedEmployee = await addEmployeeAsync(newEmployee);
            setEmployees(prevEmployees => [...prevEmployees, addedEmployee]);
            setNewEmployee({
                id: '',
                name: '',
                email: '',
                phoneNumber: '',
                address: '',
                role: RoleEnum.Guest,
            });
        } catch (error) {
            console.error('Error adding employee:', error);
        }
    };

    const handleEditEmployee = (employee: Employee) => {
        setNewEmployee(employee);
        setIsEditing(true);
    };

    const handleUpdateEmployee = async () => {
        try {
            const updatedEmployee = await updateEmployeeAsync(newEmployee);
            setEmployees(prevEmployees =>
                prevEmployees.map(emp => (emp.id === updatedEmployee.id ? updatedEmployee : emp))
            );
            setNewEmployee({
                id: '',
                name: '',
                email: '',
                phoneNumber: '',
                address: '',
                role: RoleEnum.Guest,
            });
            setIsEditing(false);
        } catch (error) {
            console.error('Error updating employee:', error);
        }
    };

    const handleDeleteEmployee = async (employeeId: string) => {
        try {
            await deleteEmployeeAsync(employeeId);
            setEmployees(prevEmployees => prevEmployees.filter(emp => emp.id !== employeeId));
        } catch (error) {
            console.error('Error deleting employee:', error);
        }
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
                    <th className="py-2 px-4 text-left">Actions</th>
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
                        <td className="py-2 px-4">
                            <button onClick={() => handleEditEmployee(employee)} className="bg-yellow-500 text-white p-1 rounded">
                                Edit
                            </button>
                            <button onClick={() => handleDeleteEmployee(employee.id)} className="bg-red-500 text-white p-1 rounded ml-2">
                                Delete
                            </button>
                        </td>
                    </tr>
                ))}
                </tbody>
            </table>
            <div className="mt-4">
                <h3 className="text-xl mb-2">{isEditing ? "Edit Employee" : "Add New Employee"}</h3>
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
                <button
                    onClick={isEditing ? handleUpdateEmployee : handleAddEmployee}
                    className="bg-blue-500 text-white p-2 rounded w-full"
                >
                    {isEditing ? "Update Employee" : "Add Employee"}
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