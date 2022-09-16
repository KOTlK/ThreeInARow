using System;
using ThreeInARow.View;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ThreeInARow.Input
{
    public class NodeClickInput : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private NodeView _node;

        public event Action<Vector2Int> Clicked;
        
        public void OnPointerClick(PointerEventData eventData)
        {
            Clicked?.Invoke(_node.Position);
        }
    }
}