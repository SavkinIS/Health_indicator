public class DamageModifyHealthButton : ModifyHealthButtonBase
{
    private IDamageable _damageable;
    
    public void Initialize(IDamageable damageable)
    {
        _damageable = damageable;
    }
    
    protected override void HealthChange()
    {
        float damage = UnityEngine.Random.Range(RandomChangeValueMin, RandomChangeValueMax);
        _damageable.TakeDamage(damage);
    }
}