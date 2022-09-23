using UnityEngine;

namespace Game.Runtime.UI.FieldSize
{
    public interface IFieldSize : IElement
    {
        Vector2Int Size { get; }
    }
}