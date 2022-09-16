using ThreeInARow.Session.Field.Nodes;

namespace ThreeInARow.View.Nodes
{
    public interface INodeView
    {
        void SetColor(Color color);
        void SetPosition(int x, int y);
    }
}