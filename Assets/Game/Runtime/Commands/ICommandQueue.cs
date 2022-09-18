namespace ThreeInARow.Commands
{
    public interface ICommandQueue<T>
    {
        bool HasUnreadCommand { get; }
        T ReadCommand();
        void Clear();
    }
}