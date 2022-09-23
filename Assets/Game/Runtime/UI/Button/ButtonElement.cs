using System;
using UnityEngine;
using UnityEngine.UI;
using UnityButton = UnityEngine.UI.Button;

namespace Game.Runtime.UI.Button
{
    [RequireComponent(typeof(Image), typeof(UnityButton))]
    public class ButtonElement : MonoBehaviour, IButton
    {
        [SerializeField] private Sprite _pressedSprite, _unpressedSprite;

        private Image _image;
        private UnityButton _button;
        
        private void Awake()
        {
            _button = GetComponent<UnityButton>();
            _image = GetComponent<Image>();
            _button.onClick.AddListener(Press);
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveListener(Press);
        }

        public bool IsActive
        {
            get => _button.interactable;
            set
            {
                if (_button.interactable != value)
                    _button.interactable = value;
            }
        }

        public bool Pressed { get; private set; } = false;
        
        public void Release()
        {
            if (Pressed == false)
                throw new InvalidOperationException($"Can't {nameof(Release)} while not {nameof(Pressed)}");
            
            Pressed = false;
            _image.sprite = _unpressedSprite;
        }

        private void Press()
        {
            Pressed = true;
            _image.sprite = _pressedSprite;
        }
        
    }
}