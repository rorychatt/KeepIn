import * as ServerTypes from "./ServerTypes.ts";
import {ServerUserResponse} from "./ServerTypes.ts";

export async function fetchModulesAsync(): Promise<ServerUserResponse> {
    try {
        const response = await fetch("http://localhost:5126/");
        if (!response.ok) {
            console.warn("Failed to fetch modules");
            return MOCK_MODULES;
        }
        return response.json();
    } catch (error) {
        console.error("Error fetching modules:", error);
        return MOCK_MODULES;
    }
}

export const MOCK_MODULES: ServerTypes.ServerUserResponse = {
    "name": "John Stevenson",
    "modules": [
        {
            "properties": {
                "name": "InventoryManager",
                "version": "1.0.0",
                "description": "Base module for KeepIn",
                "author": "KeepIn",
                "license": "MIT",
                "dependencies": {
                    "BaseModule": "1.0.0"
                }
            },
            "id": "module_c5d22458-3a6c-4a69-8e42-2451f6da1cd5"
        },
        {
            "properties": {
                "name": "InventoryManager",
                "version": "1.0.0",
                "description": "Base module for KeepIn",
                "author": "KeepIn",
                "license": "MIT",
                "dependencies": {
                    "BaseModule": "1.0.0"
                }
            },
            "id": "module_9e870d53-f814-4f97-a8b0-55062fcb83ab"
        },
        {
            "properties": {
                "name": "InventoryManager",
                "version": "1.0.0",
                "description": "Base module for KeepIn",
                "author": "KeepIn",
                "license": "MIT",
                "dependencies": {
                    "BaseModule": "1.0.0"
                }
            },
            "id": "module_b16f29c0-da4d-47a7-920d-e9e5baad0ff8"
        },
        {
            "properties": {
                "name": "InventoryManager",
                "version": "1.0.0",
                "description": "Base module for KeepIn",
                "author": "KeepIn",
                "license": "MIT",
                "dependencies": {
                    "BaseModule": "1.0.0"
                }
            },
            "id": "module_f5c255d8-68fd-4b88-843e-ca480496d5e7"
        },
        {
            "properties": {
                "name": "InventoryManager",
                "version": "1.0.0",
                "description": "Base module for KeepIn",
                "author": "KeepIn",
                "license": "MIT",
                "dependencies": {
                    "BaseModule": "1.0.0"
                }
            },
            "id": "module_35510eda-34ba-4026-ba3b-87d4ae7f0d88"
        },
        {
            "properties": {
                "name": "InventoryManager",
                "version": "1.0.0",
                "description": "Base module for KeepIn",
                "author": "KeepIn",
                "license": "MIT",
                "dependencies": {
                    "BaseModule": "1.0.0"
                }
            },
            "id": "module_3f999095-40cd-4b61-a2b5-d8e7c6b307be"
        },
        {
            "properties": {
                "name": "InventoryManager",
                "version": "1.0.0",
                "description": "Base module for KeepIn",
                "author": "KeepIn",
                "license": "MIT",
                "dependencies": {
                    "BaseModule": "1.0.0"
                }
            },
            "id": "module_259deb35-6b25-4fdd-bcee-64aa52dab86f"
        },
        {
            "properties": {
                "name": "InventoryManager",
                "version": "1.0.0",
                "description": "Base module for KeepIn",
                "author": "KeepIn",
                "license": "MIT",
                "dependencies": {
                    "BaseModule": "1.0.0"
                }
            },
            "id": "module_a8761944-6769-4bd0-a1c1-f722d009c29c"
        },
        {
            "properties": {
                "name": "InventoryManager",
                "version": "1.0.0",
                "description": "Base module for KeepIn",
                "author": "KeepIn",
                "license": "MIT",
                "dependencies": {
                    "BaseModule": "1.0.0"
                }
            },
            "id": "module_e1e1d577-2d21-457b-b960-42837b328d54"
        },
        {
            "properties": {
                "name": "InventoryManager",
                "version": "1.0.0",
                "description": "Base module for KeepIn",
                "author": "KeepIn",
                "license": "MIT",
                "dependencies": {
                    "BaseModule": "1.0.0"
                }
            },
            "id": "module_f7436cc5-1797-484d-9f59-fe222e420bd8"
        },
        {
            "properties": {
                "name": "InventoryManager",
                "version": "1.0.0",
                "description": "Base module for KeepIn",
                "author": "KeepIn",
                "license": "MIT",
                "dependencies": {
                    "BaseModule": "1.0.0"
                }
            },
            "id": "module_269dc628-fc3c-4828-83ae-0b57e7e71340"
        },
        {
            "properties": {
                "name": "InventoryManager",
                "version": "1.0.0",
                "description": "Base module for KeepIn",
                "author": "KeepIn",
                "license": "MIT",
                "dependencies": {
                    "BaseModule": "1.0.0"
                }
            },
            "id": "module_08e99595-927b-47f6-9162-0762a70697dc"
        }
    ]
}