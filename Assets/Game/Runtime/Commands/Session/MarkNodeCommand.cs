using Game.Runtime.Session;
using UnityEngine;
using Color = ThreeInARow.Session.Field.Nodes.Color;

namespace ThreeInARow.Commands.Session
{
    public class MarkNodeCommand : ISessionCommand
    {
        private readonly Vector2Int _position;
        private readonly Color _color;

        public MarkNodeCommand(Vector2Int position, Color color)
        {
            _position = position;
            _color = color;
        }

        public void Execute(ISession target)
        {
            target.Field.GetNode(_position).Mark(_color);
        }
    }
}