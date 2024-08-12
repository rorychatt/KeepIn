using KeepIn.Business.Contracts;

namespace KeepIn.Business.Core;

public class DynamicTable<TKey, TValue>(string tableName, Dictionary<TKey, TValue> data) : ITable<TKey, TValue> where TKey : notnull
{
    public string TableName { get; init; } = tableName;
    public Dictionary<TKey, TValue> Data { get; init; } = data;
}