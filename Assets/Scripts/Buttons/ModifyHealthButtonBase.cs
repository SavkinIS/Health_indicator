using UnityEngine;
using UnityEngine.UI;

public abstract class ModifyHealthButtonBase : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] protected float RandomChangeValueMin;
    [SerializeField] protected float RandomChangeValueMax;
    
    private void OnEnable()
    {
        _button.onClick.AddListener(HealthChange);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(HealthChange);
    }
    
    protected abstract void HealthChange();
}