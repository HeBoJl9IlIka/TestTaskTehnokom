namespace Company.TestTask.Model
{
    public interface IDataKeeper<T>
    {
        void SaveDate(T arg);
        T LoadDate();
    }
}
