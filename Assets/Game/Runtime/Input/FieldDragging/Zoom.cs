using UnityEngine;

namespace ThreeInARow.Input.FieldDragging
{
    public class Zoom : MonoBehaviour, IZoom
    {
        public bool Zooming { get; private set; }
        public float ZoomValue { get; private set; }

        private void Update()
        {
            var scrollDelta = UnityEngine.Input.mouseScrollDelta.y;
            if (scrollDelta != 0)
            {
                Zooming = true;
                ZoomValue = scrollDelta;
            }
            else
            {
                Zooming = false;
                ZoomValue = 0;
            }
        }
    }
}