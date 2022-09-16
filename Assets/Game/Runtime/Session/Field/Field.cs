using System;
using System.Collections.Generic;
using ThreeInARow.Session.Field.Nodes;
using ThreeInARow.View.Field;
using UnityEngine;

namespace ThreeInARow.Session.Field
{
    public class Field : IFieldGraph
    {
        private readonly INode[,] _nodes;

        private static readonly Dictionary<NodeSide, Vector2Int> _offsets = new()
        {
            {NodeSide.LeftUp, new Vector2Int(-1, 1)},
            {NodeSide.Up, new Vector2Int(0, 1)},
            {NodeSide.RightUp, new Vector2Int(1, 1)},
            {NodeSide.Left, new Vector2Int(-1, 0)},
            {NodeSide.Right, new Vector2Int(1, 0)},
            {NodeSide.LeftDown, new Vector2Int(-1, -1)},
            {NodeSide.Down, new Vector2Int(0, -1)},
            {NodeSide.RightDown, new Vector2Int(1, -1)}
        };

        public Field(INode[,] nodes)
        {
            _nodes = nodes;
            CalculateNeighbours();
        }

        public void Visualize(IFieldView view)
        {
            view.DrawNodes(_nodes);
        }

        public INode GetNode(Vector2Int position)
        {
            try
            {
                return _nodes[position.x, position.y];
            }
            catch (Exception e)
            {
                Debug.Log(e);
                return null;
            }
            
        }

        public void Write(INode node, Vector2Int position)
        {
            _nodes[position.x, position.y] = node;

            ResetNeighbours(node, position);
        }

        private void CalculateNeighbours()
        {
            for (var y = 0; y < _nodes.GetLength(1); y++)
            {
                for (var x = 0; x < _nodes.GetLength(0); x++)
                {
                    ResetNeighbours(_nodes[x, y], new Vector2Int(x, y));
                }
            }
        }

        private void ResetNeighbours(INode node, Vector2Int position)
        {
            node.ResetNeighbours(new (NodeSide, INode)[]
            {
                GetNeighbour(position, NodeSide.LeftUp),
                GetNeighbour(position, NodeSide.Up),
                GetNeighbour(position, NodeSide.RightUp),
                GetNeighbour(position, NodeSide.Left),
                GetNeighbour(position, NodeSide.Right),
                GetNeighbour(position, NodeSide.LeftDown),
                GetNeighbour(position, NodeSide.Down),
                GetNeighbour(position, NodeSide.RightDown)
            });
        }
        
        private (NodeSide, INode) GetNeighbour(Vector2Int position, NodeSide side)
        {
            return (side, GetNode(position + _offsets[side]));
        }
    }
}