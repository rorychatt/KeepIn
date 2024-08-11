export function NavBar() {
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

function openSettings() {
    console.log("Settings opened");
}