import './App.css'
import React, {lazy, Suspense, useEffect, useState} from "react";
import * as ServerTypes from "./ServerTypes.ts";
import {fetchModulesAsync} from "./api.ts";
import {NavBar} from "./Elements/NavBar.tsx";
import {LoginModal} from "./Elements/LoginModal.tsx";
import {ModuleListItem} from "./Elements/ModuleListItem.tsx";

const modulePaths: { [key: string]: React.LazyExoticComponent<React.ComponentType<{ module: ServerTypes.Module }>> } = {
    "Employee Manager": lazy(() => import('./Elements/EmployeeManager/EmployeeManagerMain.tsx')),
    // "Module Name": lazy(() => import('./Elements/ModuleName/ModuleNameMain.tsx')),
    // Add more mappings as needed
};

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

    const SelectedModuleComponent = selectedModule
        ? modulePaths[selectedModule.properties.name]
        : null;

    return (
        <div className={"min-h-screen bg-gray-100"}>
            <NavBar/>
            {selectedModule && SelectedModuleComponent ? (
                <div className="p-4">
                    <button onClick={handleBackClick} className="mb-4 text-blue-500">Back</button>
                    <Suspense fallback={<div>Loading...</div>}>
                        <SelectedModuleComponent module={selectedModule}/>
                    </Suspense>
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