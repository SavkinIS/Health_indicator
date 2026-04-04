using System;

public class Health : IHealth, IHealable, IDamageable
{
    private readonly float _min = 0f;
    private readonly float _max = 100f;

    private float _current;

    public Health()
    {
        _current = _max;
    }

    public event Action<float, float, float> Changed;
    
    public void Refresh(float changedValue = 0)
    {
        Changed?.Invoke(_current, _max, changedValue);
    }

    public void TakeDamage(float damage)
    {
        if (damage < 0)
            return;

        float previous = _current;
        _current = Math.Clamp(_current - damage, _min, _max);
        Refresh(previous - _current);
    }

    public void RestoreHealth(float additionalHealth)
    {
        if (additionalHealth < 0)
            return;

        float previous = _current;
        _current = Math.Clamp(_current + additionalHealth, _min, _max);
        Refresh(_current - previous);
    }
}