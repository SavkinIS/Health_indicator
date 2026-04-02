using UnityEngine;

public class HitButton : HealthChangeButtonBase
{
    protected override void HealthChange()
    {
        float damage = Random.Range(_randomChangeValueMin, _randomChangeValueMax);
        _healthChangerCallback?.Invoke(damage);
    }
}