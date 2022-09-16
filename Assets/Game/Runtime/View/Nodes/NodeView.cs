using System;
using ThreeInARow.View.Nodes;
using UnityEngine;
using UnityEngine.UI;
using Color = ThreeInARow.Session.Field.Nodes.Color;

namespace ThreeInARow.View
{
    public class NodeView : MonoBehaviour, INodeView
    {
        [SerializeField] private Vector2 _offset = new(17, 17);
        private Image _image;

        private void Awake()
        {
            _image = GetComponent<Image>();
        }
        
        [field: SerializeField] public Vector2Int Position { get; private set; }

        public void SetColor(Color color)
        {
            _image.color = color switch
            {
                Color.Blue => UnityEngine.Color.blue,
                Color.Red => UnityEngine.Color.red,
                Color.Yellow => UnityEngine.Color.yellow,
                _ => throw new ArgumentException(nameof(color))
            };
        }


        public void SetPosition(int x, int y)
        {
            transform.localPosition = new Vector3(x * _offset.x, y * _offset.y);
            Position = new Vector2Int(x, y);
        }
    }
}