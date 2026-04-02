using System;

public class Health : IHealth
{
    private readonly float _min = 0f;
    private readonly float _max = 100f;

    public Health()
    {
        Current = _max;
    }

    public event Action<float, float> Changed;
    
    public float Current { get; private set; }

    public float Max => _max;

    public void Refresh()
    {
        Changed?.Invoke(Current, _max);
    }
    
    public void TakeDamage(float damage)
    {
        if (damage < 0)
            return;

        Current = Math.Clamp(Current - damage, _min, _max);
        Refresh();
    }

    public void Heal(float additionalHealth)
    {
        Current = Math.Clamp(Current + additionalHealth, _min, _max);
        Refresh();
    }
}