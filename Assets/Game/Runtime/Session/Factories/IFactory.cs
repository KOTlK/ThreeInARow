namespace ThreeInARow.Session.Factories
{
    public interface IFactory<out T>
    {
        T Create();
    }
}