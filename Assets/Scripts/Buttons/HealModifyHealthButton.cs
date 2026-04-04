public class HealModifyHealthButton : ModifyHealthButtonBase
{
    private IHealable _healable;

    public void Initialize(IHealable healable)
    {
        _healable = healable;
    }
    
    protected override void ChangeHealth()
    {
        float additionalHealth = UnityEngine.Random.Range(RandomChangeValueMin, RandomChangeValueMax);
        _healable.RestoreHealth(additionalHealth);
    }
}