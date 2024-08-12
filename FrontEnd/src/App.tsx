import './App.css'
import React, {useEffect, useState} from "react";
import * as ServerTypes from "./ServerTypes.ts";
import {fetchModulesAsync} from "./api.ts";
import {NavBar} from "./Elements/NavBar.tsx";
import {LoginModal} from "./Elements/LoginModal.tsx";
import {ModuleListItem} from "./Elements/ModuleListItem.tsx";



function MainWindow({isAuthenticated}: {
    isAuthenticated: boolean,
    setIsAuthenticated: React.Dispatch<React.SetStateAction<boolean>>
}) {

    const [modules, setModules] = useState<ServerTypes.Module[]>([]);
    const [selectedModule, setSelectedModule] = useState<ServerTypes.Module | null>(null);
    
    useEffect(() => {
        if (isAuthenticated) {
            fetchModulesAsync()
                .then((response) => setModules(response.modules))
                .catch((error: Error) => console.error(error));
        }
    }, [isAuthenticated]); //TODO: read more about this

    const handleModuleClick = (module: ServerTypes.Module) => {
        setSelectedModule(module);
    };
    const handleBackClick = () => {
        setSelectedModule(null);
    };

    return (
        <div className={"min-h-screen bg-gray-100"}>
            <NavBar/>
            {selectedModule ? (
                <div className="p-4">
                    <button onClick={handleBackClick} className="mb-4 text-blue-500">Back</button>
                    <div>
                        {/* Render the selected module's content here */}
                        <h2 className="text-2xl font-bold mb-4">{selectedModule.properties.name}</h2>
                        <p>{selectedModule.properties.description}</p>
                    </div>
                </div>
            ) : (
                <article className="p-4 flex flex-wrap justify-center gap-4">
                    {modules.map((module: ServerTypes.Module) => (
                        <ModuleListItem key={module.id} module={module} onClick={() => handleModuleClick(module)}/>
                    ))}
                </article>
            )}
        </div>
    );
}

export default function App() {
    const [isAuthenticated, setIsAuthenticated] = useState(false);

    return (
        <>
            {isAuthenticated ? (
                <MainWindow isAuthenticated={isAuthenticated} setIsAuthenticated={setIsAuthenticated}/>
            ) : (
                <LoginModal setIsAuthenticated={setIsAuthenticated}/>
            )}
        </>
    );
}