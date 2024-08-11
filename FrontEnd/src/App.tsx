import './App.css'
import React, {useEffect, useState} from "react";
import * as ServerTypes from "./ServerTypes.ts";
import {fetchModulesAsync} from "./api.ts";
import {NavBar} from "./Elements/NavBar.tsx";
import {LoginModal} from "./Elements/LoginModal.tsx";
import {Module} from "./Elements/Module.tsx";



function MainWindow({isAuthenticated}: {
    isAuthenticated: boolean,
    setIsAuthenticated: React.Dispatch<React.SetStateAction<boolean>>
}) {

    const [modules, setModules] = useState<ServerTypes.Module[]>([]);

    useEffect(() => {
        if (isAuthenticated) {
            fetchModulesAsync()
                .then((response) => setModules(response.modules))
                .catch((error: Error) => console.error(error));
        }
    }, [isAuthenticated]); //TODO: read more about this

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