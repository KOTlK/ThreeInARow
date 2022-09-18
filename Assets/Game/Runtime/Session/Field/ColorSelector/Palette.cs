using UnityEngine;
using Color = ThreeInARow.Session.Field.Nodes.Color;

namespace ThreeInARow.Session.Field.ColorSelector
{
    public class Palette : MonoBehaviour, IPalette
    {
        [SerializeField] private PaletteColor[] _colors;

        private void Awake()
        {
            foreach (var color in _colors)
            {
                color.Clicked += SelectColor;
            }
            
            Current = _colors[0].Color;
        }

        public Color Current { get; private set; }
        
        public void SelectColor(Color color)
        {
            Current = color;
        }
    }
}