namespace KeepIn.Business.Contracts;

public interface ITable<TKey, TValue> where TKey : notnull
{
    public Dictionary<TKey, TValue> Data { get; init; }
    
}