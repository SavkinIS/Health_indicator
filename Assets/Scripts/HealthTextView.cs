using TMPro;
using UnityEngine;

public class HealthTextView : HealthViewBase
{
    [SerializeField] private TMP_Text _text;

    protected override void OnHealthChanged(float current, float max, float normalized)
    {
        _text.text = $"{current.ToString("##")}/{max.ToString("##")}";
    }
}