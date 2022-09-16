using ThreeInARow.Session.Field.Nodes;

namespace ThreeInARow.View.Field
{
    public interface IFieldView
    {
        void DrawNodes(INode[,] nodes);
    }
}