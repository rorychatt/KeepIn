namespace KeepIn.Business.Contracts;

public interface ITable<T, V>
{
    public Dictionary<T, V> Data { get; init; }
    
}