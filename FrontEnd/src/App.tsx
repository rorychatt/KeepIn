import './App.css'
import {useEffect, useState} from "react";
import * as ServerTypes from "./ServerTypes.ts";
import {fetchModulesAsync} from "./api.ts";

function openSettings() {
    console.log("Settings opened");
}

function NavBar() {
    return (
        <nav className={"bg-gray-800 p-4 flex justify-between items-center"}>
            <h2 className="text-white text-lg">KeepIn</h2>
            <div className="flex items-center cursor-pointer" onClick={openSettings}>
                <span className="text-white ml-2 mr-2">Settings</span>
                <img
                    src="/icons/gear_icon_white.png"
                    alt="Settings"
                    className="w-6 h-6 icon-white"
                />
            </div>
        </nav>
    )
}

function Module({module}: { module: ServerTypes.Module }) {
    return (
        <article className="border p-4 flex flex-col items-center gap-2 shadow-sm hover:shadow-md transition-shadow">
            <img src="/images/placeholder_128x128.png" alt="Module Icon" className={""}/>
            <span>{module.properties.name}</span>
            <span>{module.properties.version}, {module.properties.author}</span>
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
                    modules.map((module: ServerTypes.Module) => <Module key={module.id} module={module}/>)
                }
            </article>
        </div>
    )
}