using System;

public class Health : IHealth
{
    private readonly float _min = 0f;
    private readonly float _max = 100f;
    private float _changedValue;

    public Health()
    {
        Current = _max;
    }

    public event Action<float, float, float> Changed;
    
    public float Current { get; private set; }

    public float Max => _max;

    public void Refresh()
    {
        Changed?.Invoke(Current, _max, _changedValue);
        _changedValue = 0;
    }
    
    public void TakeDamage(float damage)
    {
        if (damage < 0)
            return;

        float previous = Current;
        Current = Math.Clamp(Current - damage, _min, _max);
        _changedValue = previous - Current;
        Refresh();
    }

    public void Heal(float additionalHealth)
    {
        float previous = Current;
        Current = Math.Clamp(Current + additionalHealth, _min, _max);
        _changedValue = Current - previous;
        Refresh();
    }
}