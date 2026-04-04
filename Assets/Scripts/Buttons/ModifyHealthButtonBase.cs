using UnityEngine;
using UnityEngine.UI;

public abstract class ModifyHealthButtonBase : MonoBehaviour
{
    [SerializeField] protected float RandomChangeValueMin;
    [SerializeField] protected float RandomChangeValueMax;
    [SerializeField] private Button _button;

    private void OnEnable()
    {
        _button.onClick.AddListener(ChangeHealth);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(ChangeHealth);
    }
    
    protected abstract void ChangeHealth();
}