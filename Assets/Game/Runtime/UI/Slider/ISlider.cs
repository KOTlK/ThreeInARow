using System;

namespace Game.Runtime.UI.Slider
{
    public interface ISlider : IElement
    {
        event Action<float> ValueChanged; 
        float Value { get; }
    }
}