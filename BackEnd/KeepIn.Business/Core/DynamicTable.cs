using KeepIn.Business.Contracts;

namespace KeepIn.Business.Core;

public class DynamicTable<T, V>(string tableName, Dictionary<T, V> data) : ITable<T, V>
{
    public string TableName { get; init; } = tableName;
    public Dictionary<T, V> Data { get; init; } = data;
}