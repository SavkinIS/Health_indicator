using System;
using UnityEngine;

public class HealthViewHandler : MonoBehaviour
{
    [SerializeField] private HealthViewBase[] _healthViews;
    [SerializeField] private HealButton _healButton;
    [SerializeField] private HitButton _hitButton;
    
    private Health _health;
    
    private void Awake()
    {
        _health = new Health();
        _hitButton.SetClickCallback(_health.TakeDamage);
        _healButton.SetClickCallback(_health.Heal);
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