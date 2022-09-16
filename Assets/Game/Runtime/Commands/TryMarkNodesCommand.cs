using ThreeInARow.Session.Field;
using ThreeInARow.Session.Field.Nodes;
using UnityEngine;

namespace ThreeInARow.Commands
{
    public class TryMarkNodesCommand : IFieldCommand
    {
        private readonly Vector2Int _position;

        public TryMarkNodesCommand(Vector2Int position)
        {
            _position = position;
        }

        public void Execute(IFieldGraph target)
        {
            var targetNode = target.GetNode(_position);
            TryMarkNeighbour(targetNode, NodeSide.Up);
            TryMarkNeighbour(targetNode, NodeSide.Down);
            TryMarkNeighbour(targetNode, NodeSide.Left);
            TryMarkNeighbour(targetNode, NodeSide.Right);
            targetNode.Mark();
        }

        private void TryMarkNeighbour(INode node, NodeSide side)
        {
            var color = node.Color;
            
            while (true)
            {
                var neighbour = node.GetNeighbour(side);
                
                if (neighbour == null) return;

                if (neighbour.Color == color)
                {
                    neighbour.Mark();
                    node = neighbour;
                    continue;
                }

                break;
            }
        }
    }
}