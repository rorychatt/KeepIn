namespace KeepIn.Business.Contracts;

public interface ITable<TKey, TValue> where TKey : notnull
{
    public string TableName { get; init; }
    public Dictionary<TKey, TValue> Data { get; init; }
    public TValue? Get(TKey key)
    {
        return Data.GetValueOrDefault(key);
    }
    public void Add(TKey key, TValue value)
    {
        Data[key] = value;
    }
}