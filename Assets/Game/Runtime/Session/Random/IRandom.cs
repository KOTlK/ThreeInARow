namespace ThreeInARow.Session.Random
{
    public interface IRandom<out T>
    {
        T Next();
    }
}