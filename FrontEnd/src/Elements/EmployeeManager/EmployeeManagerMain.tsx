
import {Module, Employee, RoleEnum} from "../../ServerTypes.ts";
import { fetchEmployeesAsync } from "../../api.ts";
import {useEffect, useState} from "react";

function EmployeesTable() {
    const [employees, setEmployees] = useState<Employee[]>([]);

    useEffect(() => {
        fetchEmployeesAsync()
            .then(setEmployees)
            .catch(error => console.error('Error fetching employees:', error));
    }, []);

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