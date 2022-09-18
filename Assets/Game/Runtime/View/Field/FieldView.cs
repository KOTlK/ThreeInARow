using System;
using System.Collections.Generic;
using ThreeInARow.Input;
using ThreeInARow.Input.FieldDragging;
using ThreeInARow.Session.Field.Nodes;
using UnityEditor;
using UnityEngine;

namespace ThreeInARow.View.Field
{
    public class FieldView : MonoBehaviour, IFieldView
    {
        [SerializeField] private NodeView _nodePrefab;
        [SerializeField] private RectTransform _elementsHolder;
        [SerializeField] private ClickInputs _clicks;
        [SerializeField] private FieldDrag _drag;
        [SerializeField] private float _dragSpeed = 1000f;
        [SerializeField] private Zoom _zoom;
        [SerializeField] private float _zoomMultiplier = 10f;

        private readonly Dictionary<INode, NodeView> _nodes = new();

        private const float MinScale = 1f;
        private const float MaxScale = 7f;
        
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
                    
                    var nodeObject = Instantiate(_nodePrefab, _elementsHolder);
                    nodeObject.SetPosition(x, y);
                    nodeObject.SetColor(node.Color);
                    _nodes.Add(node, nodeObject);
                    _clicks.Append(nodeObject.GetComponent<NodeClickInput>());
                }
            }
        }

        private void Update()
        {
            if (_drag.Dragging)
            {
                MoveField(_drag.Direction);
            }

            if (_zoom.Zooming)
            {
                Zoom(_zoom.ZoomValue);
            }
        }

        private void MoveField(Vector2 direction)
        {
            _elementsHolder.anchoredPosition += direction * _dragSpeed * _elementsHolder.localScale.x * Time.deltaTime;
        }

        private void Zoom(float value)
        {
            var localScale = _elementsHolder.localScale.x;
            localScale += value * _zoomMultiplier * Time.deltaTime;
            localScale = Mathf.Clamp(localScale, MinScale, MaxScale);
            
            _elementsHolder.localScale = new Vector3(localScale, localScale, 1);
        }
    }
}