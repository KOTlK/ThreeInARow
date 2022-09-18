using UnityEngine;

namespace ThreeInARow.Input.FieldDragging
{
    public interface IDrag
    {
        bool Dragging { get; }
        Vector2 Direction { get; }
    }
}