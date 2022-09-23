using Game.Runtime.UI.Button;
using Game.Runtime.UI.FieldSize;

namespace Game.Runtime.UI.MainMenu
{
    public interface ISetSizeMenu : IElement
    {
        IButton StartButton { get; }
        IFieldSize FieldSize { get; }
    }
}