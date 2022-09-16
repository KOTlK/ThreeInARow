using ThreeInARow.Session.Field;
using ThreeInARow.Session.Field.Nodes;
using ThreeInARow.Session.Random;
using UnityEngine;
using Color = ThreeInARow.Session.Field.Nodes.Color;

namespace ThreeInARow.Session.Factories
{
    public class FieldFactory : IFactory<IFieldGraph>
    {
        private readonly Vector2Int _size;
        private readonly IRandom<Color> _colorGenerator;

        public FieldFactory(Vector2Int size, IRandom<Color> colorGenerator)
        {
            _size = size;
            _colorGenerator = colorGenerator;
        }

        public IFieldGraph Create()
        {
            var nodes = new INode[_size.x, _size.y];

            for (var y = 0; y < _size.y; y++)
            {
                for (var x = 0; x < _size.x; x++)
                {
                    nodes[x, y] = new Node(_colorGenerator.Next());
                }
            }

            return new Field.Field(nodes);
        }
    }
}