using Game.Runtime.UI.Button;

namespace Game.Runtime.UI.MainMenu
{
    public interface IStartMenu : IElement
    {
        IButton StartGameButton { get; }
        IButton LoadCanvasButton { get; }
        IButton ExitButton { get; }
    }
}