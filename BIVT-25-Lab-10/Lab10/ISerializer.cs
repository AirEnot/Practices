namespace Lab10.Purple
{
    public interface ISerializer<T>(T obj) where T : Lab9.Purple.Purple
    {
        void Serialize(T obj);

    }
}