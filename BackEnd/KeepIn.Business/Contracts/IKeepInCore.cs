﻿using KeepIn.Business.Contracts;

namespace KeepIn.Business.Core;

public interface IKeepInCore
{
    public Dictionary<string, IModule> ActivatedModules { get; init; }
    
    public void ActivateModule(IModule module);
    public void DeactivateModule(IModule module);
    public bool InjectTable(string tableName,
        ITable<string, string[]> data);
    
}