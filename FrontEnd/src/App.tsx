import './App.css'
import {useEffect, useState} from "react";
import module = require("vite");

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

    const [modules, setModules] = useState([]);

    useEffect(() => {
        fetch("http://localhost:5126/")
            .then(response => response.json())
            .then(data => setModules(data))
            .catch(error => console.error("Error fetching modules: ", error));
    }, []);

    return (
        <div className={"min-h-screen bg-gray-100"}>
            <NavBar/>
            <article className="p-4 flex flex-wrap justify-center gap-4">
                {
                    modules.map((module: any) => <Module key={module.id}/>)
                }
            </article>
        </div>
    )
}