﻿using KeepIn.Business.Contracts;

namespace KeepIn.Business.Users;

public class User(string name) : IUser
{
    public string Id { get; init; } = $"user_{Guid.NewGuid()}";
    public string Name { get; set; } = name;

    public IEnumerable<IModule> ActiveModules
    {
        get => _activeModules;
        set => _activeModules = value.ToList();
    }

    private List<IModule> _activeModules = [];

    public void RegisterNewModule(IModule module)
    {
        _activeModules.Add(module);
    }
}