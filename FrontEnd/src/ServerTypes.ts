export type Module = {
    id: string;
    properties: ModuleProperties;
}
    
export type ModuleProperties = {
    name: string,
    version: string,
    description: string,
    author: string,
    license: string,
    dependencies: Record<string, string>
}

export type ServerUserResponse = {
    name: string;
    modules: Module[];
}