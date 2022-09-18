using ThreeInARow.Session.Field.Nodes;

namespace ThreeInARow.Session.Field.ColorSelector
{
    public interface IPalette
    {
        Color Current { get; }
        void SelectColor(Color color);
    }
}