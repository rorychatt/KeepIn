import {Module} from "../../ServerTypes.ts";

const EmployeeManagerMain = ({module}: {module: Module})  =>{
    return <div>
        <h2 className="text-2xl font-bold mb-4">{module.properties.name}</h2>
        <p>{module.properties.description}</p>
    </div>
}

export default EmployeeManagerMain