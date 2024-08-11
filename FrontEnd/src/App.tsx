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
            <h2 className="text-white text-lg ml-8">KeepIn</h2>
            <div className="flex items-center cursor-pointer mr-8" onClick={openSettings}>
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
        <article
            className="border p-4 flex flex-col items-center gap-2 shadow-sm hover:shadow-md transition-shadow w-40">
            <img src="/images/placeholder_128x128.png" alt="Module Icon" className={""}/>
            <h2 className={"text-center"}>{module.properties.name}</h2>
            <h3>{module.properties.version}, {module.properties.author}</h3>
        </article>
    );
}

export default function App() {

    const [modules, setModules] = useState<ServerTypes.Module[]>([]);
    const [isAuthenticated, setIsAuthenticated] = useState(false);
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');


    useEffect(() => {
        if (!isAuthenticated) {
            fetchModulesAsync()
                .then((response) => setModules(response.modules))
                .catch((error: Error) => console.error(error));
        }
    }, [isAuthenticated]); //TODO: read more about this
    
    const handleLogin = async () => {
        try {
            const response = await fetch("http://localhost:5126/api/Users/login", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify({username, password})
            });

            if (response.ok) {
                setIsAuthenticated(true);
            } else {
                alert('Login failed');
            }
        } catch (error) {
            console.error("Error logging in:", error);
        }
    }
    
    if (!isAuthenticated) {
        return (
            <div className="min-h-screen bg-gray-100 flex items-center justify-center">
                <div className="bg-white p-8 rounded shadow-md">
                    <h2 className="text-2xl mb-4">Login</h2>
                    <input
                        type="text"
                        placeholder="Username"
                        value={username}
                        onChange={(e) => setUsername(e.target.value)}
                        className="mb-4 p-2 border rounded w-full"
                    />
                    <input
                        type="password"
                        placeholder="Password"
                        value={password}
                        onChange={(e) => setPassword(e.target.value)}
                        className="mb-4 p-2 border rounded w-full"
                    />
                    <button onClick={handleLogin} className="bg-blue-500 text-white p-2 rounded w-full">
                        Login
                    </button>
                </div>
            </div>
        );
    }

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