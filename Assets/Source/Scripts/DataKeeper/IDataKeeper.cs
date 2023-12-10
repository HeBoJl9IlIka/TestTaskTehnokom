namespace Company.TestTask.Model
{
    public interface IDataKeeper<T>
    {
        void Save(T arg);
        T Load();
    }
}
