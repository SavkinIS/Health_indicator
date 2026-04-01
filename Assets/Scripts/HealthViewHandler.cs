using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class HealthViewHandler : MonoBehaviour
{
    [SerializeField] private HealthViewBase[] _healthViews;
    [SerializeField] private Button _hitButton;
    [SerializeField] private Button _healButton;

    private readonly float _maxHealth = 100;
    private readonly float _randomChangeValueMax = 20f;
    private readonly float _randomChangeValueMin = 10f;
    private readonly float _minHealth = 0f;
    
    private float _current;
    private event Action<float, float> HealthChanged;

    private void Awake()
    {
        _current = _maxHealth;
    }

    private void OnEnable()
    {
        _hitButton.onClick.AddListener(TakeDamage);
        _healButton.onClick.AddListener(Heal);
        
        foreach (HealthViewBase healthView in _healthViews)
        {
            HealthChanged += healthView.OnHealthChangedInternal;
        }
    }
    
    private void OnDisable()
    {
        _hitButton.onClick.RemoveAllListeners();
        _healButton.onClick.RemoveAllListeners();
        
        foreach (HealthViewBase healthView in _healthViews)
        {
            HealthChanged -= healthView.OnHealthChangedInternal;
        }
    }

    private void TakeDamage()
    {
        float damage = Random.Range(_randomChangeValueMin, _randomChangeValueMax);
        _current = Math.Clamp(_current - damage,  _minHealth, _maxHealth);
        
        HealthChanged?.Invoke(_current, _maxHealth);
    }
    
    private void Heal()
    {
        float additionalHealth = Random.Range(_randomChangeValueMin, _randomChangeValueMax);
        _current = Math.Clamp(_current + additionalHealth,  _minHealth, _maxHealth);
        
        HealthChanged?.Invoke(_current, _maxHealth);
    }
    
}