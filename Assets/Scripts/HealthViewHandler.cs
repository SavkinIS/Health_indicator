using System;
using UnityEngine;

public class HealthViewHandler : MonoBehaviour
{
    [SerializeField] private HealthViewBase[] _healthViews;
    [SerializeField] private DamageModifyHealthButton _hitButton;
    [SerializeField] private HealModifyHealthButton _healButton;

    private IHealth _health;

    private void Awake()
    {
        var health = new Health();
        _health = health;
        _hitButton.Initialize(health);
        _healButton.Initialize(health);
    }

    private void OnEnable()
    {
        foreach (HealthViewBase healthView in _healthViews)
        {
            if (_health != null)
            {
                _health.Changed += healthView.HealthChangedInternal;
            }
        }

        _health?.Refresh();
    }

    private void OnDisable()
    {
        foreach (HealthViewBase healthView in _healthViews)
        {
            if (_health != null)
            {
                _health.Changed -= healthView.HealthChangedInternal;
            }
        }
    }
}