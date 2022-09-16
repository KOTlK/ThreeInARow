using System.Collections.Generic;

namespace ThreeInARow.Session.Field.Nodes
{
    public class Node : INode
    {
        private readonly Dictionary<NodeSide, INode> _neighbours = new();

        public Node(Color color)
        {
            Color = color;
        }

        public Color Color { get; private set; }
        
        public INode GetNeighbour(NodeSide side) => _neighbours[side];
        
        public void ResetNeighbours((NodeSide, INode)[] neighbours)
        {
            _neighbours.Clear();
            foreach (var (side, node) in neighbours)
            {
                _neighbours.Add(side, node);
            }
        }

        public void Mark()
        {
            Color = Color.Red;
        }
    }
}