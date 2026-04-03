using UnityEngine;
using UnityEngine.UI;

public class HealthBarView : HealthViewBase
{
    [SerializeField] protected Slider _slider;

    protected override void HealthChanged(float current, float max, float normalized)
    {
        _slider.value = normalized;
    }
}