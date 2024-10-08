﻿import * as ServerTypes from "../ServerTypes.ts";

export function ModuleListItem({module, onClick}: { module: ServerTypes.Module, onClick: () => void }) {
    return (
        <article
            className="border p-4 flex flex-col items-center gap-2 shadow-sm hover:shadow-md transition-shadow w-40 cursor-pointer"
            onClick={onClick}
        >
            <img src="/images/placeholder_128x128.png" alt="Module Icon" className={""}/>
            <h2 className={"text-center"}>{module.properties.name}</h2>
            <h3>{module.properties.version}, {module.properties.author}</h3>
        </article>
    );
}
