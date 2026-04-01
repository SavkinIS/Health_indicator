using UnityEngine;

public abstract class HealthViewBase : MonoBehaviour
{
    public void OnHealthChangedInternal(float current, float max)
    {
        float normalized = current <= 0 ? 0 : current / max;
        OnHealthChanged(current, max, normalized);
    }

    protected abstract void OnHealthChanged(float current, float max, float normalized);
}