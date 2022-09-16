using System;
using ThreeInARow.Session.Field.Nodes;

namespace ThreeInARow.Session.Random
{
    public class RandomColor : IRandom<Color>
    {
        private readonly Array _values;
        private readonly System.Random _random;

        public RandomColor()
        {
            _values = Enum.GetValues(typeof(Color));
            _random = new System.Random();
        }

        public Color Next()
        {
            return (Color)_values.GetValue(_random.Next(_values.Length));
        }
    }
}