namespace Game.Runtime.UI.MainMenu
{
    public interface IMainMenu : IElement
    {
        ISetSizeMenu SetSizeMenu { get; }
        IStartMenu StartMenu { get; }
    }
}