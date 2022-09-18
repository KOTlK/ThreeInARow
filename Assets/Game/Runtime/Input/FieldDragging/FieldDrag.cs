using System;
using UnityEngine;

namespace ThreeInARow.Input.FieldDragging
{
    public class FieldDrag : MonoBehaviour, IDrag
    {
        [SerializeField] private KeyCode _key = KeyCode.Mouse1;

        private Vector3 _previousPosition;

        public bool Dragging { get; private set; }
        public Vector2 Direction { get; private set; }

        private void Update()
        {
            if (UnityEngine.Input.GetKeyDown(_key))
            {
                Dragging = true;
                _previousPosition = UnityEngine.Input.mousePosition;
            }

            if (UnityEngine.Input.GetKey(_key))
            {
                var mousePosition = UnityEngine.Input.mousePosition;
                Direction = (mousePosition - _previousPosition).normalized;
                _previousPosition = mousePosition;
            }

            if (UnityEngine.Input.GetKeyUp(_key))
            {
                Dragging = false;
            }
        }
    }
}