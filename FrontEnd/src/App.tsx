import './App.css'


// const Navbar: React.FC = () => {
//     return (
//         <nav className="bg-gray-800 p-4 flex justify-between items-center">
//             <div className="text-white text-lg">My App</div>
//             <FaCog className="text-white text-2xl cursor-pointer" />
//         </nav>
//     );
// };
//
// const Module: React.FC<{ icon: React.ReactNode; name: string }> = ({ icon, name }) => {
//     return (
//         <div className="bg-white p-4 rounded shadow hover:bg-gray-100 cursor-pointer flex items-center space-x-2">
//             <div className="text-2xl">{icon}</div>
//             <div className="text-lg">{name}</div>
//         </div>
//     );
// };
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
    return (
        <div className={"min-h-screen bg-gray-100"}>
            <NavBar/>
            <article className="p-4 flex flex-wrap justify-center gap-4">
                <Module/>
                <Module/>
                <Module/>
                <Module/>
                <Module/>
                <Module/>
                <Module/>
                <Module/>
                <Module/>
                <Module/>
                <Module/>
                <Module/>
                <Module/>
            </article>
        </div>
    )
}