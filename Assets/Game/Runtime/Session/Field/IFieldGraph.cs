using ThreeInARow.Session.Field.Nodes;
using ThreeInARow.View;
using ThreeInARow.View.Field;
using UnityEngine;

namespace ThreeInARow.Session.Field
{
    public interface IFieldGraph : IVisualization<IFieldView>
    {
        INode GetNode(Vector2Int position);
        void Write(INode node, Vector2Int position);
    }
}