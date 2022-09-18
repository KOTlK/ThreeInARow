using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Color = ThreeInARow.Session.Field.Nodes.Color;

namespace ThreeInARow.Session.Field.ColorSelector
{
    [ExecuteInEditMode]
    public class PaletteColor : MonoBehaviour, IPointerClickHandler
    {
        public event Action<Color> Clicked;

        [field: SerializeField] public Color Color { get; private set; }

#if UNITY_EDITOR
        private void OnGUI()
        {
            SwitchColor();
        }

        private void SwitchColor()
        {
            var image = GetComponent<Image>();

            image.color = Color switch
            {
                Color.Red => UnityEngine.Color.red,
                Color.Blue => UnityEngine.Color.blue,
                Color.Yellow => UnityEngine.Color.yellow,
                _ => image.color
            };
        }
#endif

        public void OnPointerClick(PointerEventData eventData)
        {
            Clicked?.Invoke(Color);
        }
    }
}