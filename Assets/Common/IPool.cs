namespace Common
{
    public interface IPool<T>
    {
        T Get();
        void Return(T item);
    }
}