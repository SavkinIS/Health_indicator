using UnityEngine;

public class HealButton : HealthChangeButtonBase
{
    protected override void HealthChange()
    {
        float additionalHealth = Random.Range(_randomChangeValueMin, _randomChangeValueMax);
        _healthChangerCallback?.Invoke(additionalHealth);
    }
}