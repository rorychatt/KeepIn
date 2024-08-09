import './App.css'
import {useEffect, useState} from "react";
import * as ServerTypes from "./ServerTypes.ts";
import {fetchModulesAsync} from "./api.ts";

function NavBar() {
    return (
        <nav className={"bg-gray-800 p-4 flex justify-between items-center"}>
            <div className="text-white text-lg">KeepIn</div>
            <div className="text-white text-2xl cursor-pointer"/>
        </nav>
    )
}

function Module() {
    return (
        <article className="border p-4 flex flex-col items-center gap-2 shadow-sm hover:shadow-md transition-shadow">
            <img src="https://via.placeholder.com/128" alt="Module Icon" className={""}/>
            <span>Short Name</span>
        </article>
    );
}

export default function App() {

    const [modules, setModules] = useState<ServerTypes.Module[]>([]);

    useEffect(() => {
        fetchModulesAsync()
            .then((response) => setModules(response.modules))
            .catch((error: Error) => console.error(error));
    }, []);

    return (
        <div className={"min-h-screen bg-gray-100"}>
            <NavBar/>
            <article className="p-4 flex flex-wrap justify-center gap-4">
                {
                    modules.map((module: ServerTypes.Module) => <Module key={module.id}/>)
                }
            </article>
        </div>
    )
}