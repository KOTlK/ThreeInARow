using System;
using UnityEngine;
using UnitySlider = UnityEngine.UI.Slider;

namespace Game.Runtime.UI.Slider
{
    [RequireComponent(typeof(UnitySlider))]
    public class SliderElement : MonoBehaviour, ISlider
    {
        public event Action<float> ValueChanged; 

        private UnitySlider _slider;

        private void Awake()
        {
            _slider = GetComponent<UnitySlider>();
            _slider.onValueChanged.AddListener(OnValueChanged);
        }

        private void OnDestroy()
        {
            _slider.onValueChanged.RemoveListener(OnValueChanged);
        }

        public float Value => _slider.value;

        public bool IsActive
        {
            get => _slider.interactable;
            set
            {
                if (_slider.interactable != value)
                    _slider.interactable = value;
            }
        }

        private void OnValueChanged(float value)
        {
            ValueChanged?.Invoke(value);
        }
    }
}