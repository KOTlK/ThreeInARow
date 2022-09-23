namespace Game.Runtime.UI.Button
{
    public interface IButton : IElement
    {
        bool Pressed { get; }
        void Release();
    }
}