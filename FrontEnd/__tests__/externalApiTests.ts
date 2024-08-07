import * as path from "node:path";

const API_URL = "http:/localhost:5126/Api/Users";

describe("External API Tests", () => {
    
    test("Should connect to the external API", async () => {
        const response = await fetch(API_URL);
        expect(response.status).toBe(200);
    });
    
    test("Should return a JSON response", async () => {
        const response = await fetch(path.join(API_URL, "literally_anything"));
        const data = await response.json();
        expect(data).toBeDefined();
    });

});