using System.Collections.Generic;
using ThreeInARow.Session.Field.Nodes;
using UnityEngine;

namespace ThreeInARow.View.Field
{
    public class FieldView : MonoBehaviour, IFieldView
    {
        [SerializeField] private NodeView _nodePrefab;

        private readonly Dictionary<INode, NodeView> _nodes = new();

        public void DrawNodes(INode[,] nodes)
        {
            for(var y = 0; y < nodes.GetLength(1); y++)
            {
                for (var x = 0; x < nodes.GetLength(0); x++)
                {
                    var node = nodes[x, y];

                    if (_nodes.ContainsKey(node))
                    {
                        _nodes[node].SetColor(node.Color);
                        continue;
                    }
                    
                    var nodeObject = Instantiate(_nodePrefab, transform);
                    nodeObject.SetPosition(x, y);
                    nodeObject.SetColor(node.Color);
                    _nodes.Add(node, nodeObject);
                }
            }
        }
    }
}