import {describe, expect, test} from "vitest";
import {fetchModulesAsync} from "../src/api";

describe("fetchModules", () => {
    test("should not crash", async () => {
        const response = await fetchModulesAsync();
        expect(response).toBeDefined();
    })

    test("should return an array", async () => {
        const response = await fetchModulesAsync();
        expect(Array.isArray(response.modules)).toBe(true);
    })
})