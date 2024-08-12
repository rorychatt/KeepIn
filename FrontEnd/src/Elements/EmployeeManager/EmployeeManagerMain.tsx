import {Module} from "../../ServerTypes.ts";


function EmployeesTable() {
    return <table>
        <thead>
        <tr>
            <th>Name</th>
            <th>Email</th>
            <th>Phone Number</th>
            <th>Address</th>
            <th>Role</th>
        </tr>
        </thead>
        <tbody>
        <tr>
            <td>The best dude ever</td>
            <td>test@gmail.com</td>
            <td>07612311</td>
            <td>None of your business</td>
            <td>1</td>
        </tr>
        </tbody>
    </table>
}

const EmployeeManagerMain = ({module}: { module: Module }) => {
    return <div>
        <h2 className="text-2xl font-bold mb-4">{module.properties.name}</h2>
        <p>{module.properties.description}</p>
        <EmployeesTable/>
    </div>
}

export default EmployeeManagerMain