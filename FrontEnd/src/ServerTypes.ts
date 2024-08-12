﻿export type Module = {
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

export type ServerEmployeesResponse = Employee[]

export type Employee = {
    id: string;
    name: string;
    email: string;
    phoneNumber: string;
    address: string;
    role: Role;
}

export type ServerUserResponse = {
    name: string;
    modules: Module[];
}

export type LoginUserResponse = {
    name: string;
    accessLevel: string;
}

export enum Role {
    Guest,
    Worker,
    Manager,
    Admin
}