using System;
using TMPro;
using UnityEngine;

namespace Game.Runtime.UI.FieldSize
{
    [RequireComponent(typeof(TMP_Text))]
    public class FieldSize : MonoBehaviour, IFieldSize
    {
        [SerializeField] private Vector2 _minValue = new(10, 10);
        [SerializeField] private Vector2 _maxValue = new(100, 100);
        [SerializeField] private Slider.SliderElement _sliderElement;
        
        private TMP_Text _text;

        private void Awake()
        {
            _text = GetComponent<TMP_Text>();
            _sliderElement.ValueChanged += SetText;
        }

        private void Start()
        {
            SetText(_sliderElement.Value);
        }

        private void OnDestroy()
        {
            _sliderElement.ValueChanged -= SetText;
        }

        public bool IsActive
        {
            get => gameObject.activeSelf;
            set
            {
                if (gameObject.activeSelf != value)
                    gameObject.SetActive(value);
            }
        }

        public Vector2Int Size
        {
            get
            {
                var value = Vector2.Lerp(_minValue, _maxValue, _sliderElement.Value);

                return new Vector2Int((int)value.x, (int)value.y);
            }
        }

        private void SetText(float value)
        {
            var size = Size;

            _text.text = $"{size.x}x{size.y}";
        }
    }
}