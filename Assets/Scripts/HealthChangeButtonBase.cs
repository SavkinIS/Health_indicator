using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class HealthChangeButtonBase : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] protected float _randomChangeValueMin;
    [SerializeField] protected float _randomChangeValueMax;
    
    protected Action<float> _healthChangerCallback;

    public void SetClickCallback(Action<float> healthChangerCallback)
    {
        _healthChangerCallback = healthChangerCallback;
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(HealthChange);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(HealthChange);
    }

    protected abstract void HealthChange();
}