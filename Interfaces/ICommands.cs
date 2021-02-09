interface ICommands<T>
{
    public bool save(T item);
    public bool remove(T item);
}