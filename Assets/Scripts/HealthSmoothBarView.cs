using System.Collections;
using UnityEngine;

public class HealthSmoothBarView : HealthBarView
{
    [SerializeField] private float _speed = 5f;

    private float _targetValue;
    private Coroutine _fillCoroutine;

    protected override void OnHealthChanged(float current, float max, float normalized)
    {
        _targetValue = normalized;

        if (_fillCoroutine != null)
            StopCoroutine(_fillCoroutine);

        _fillCoroutine = StartCoroutine(FillCoroutine());
    }

    private IEnumerator FillCoroutine()
    {
        while (!Mathf.Approximately(_slider.value, _targetValue))
        {
            _slider.value = Mathf.MoveTowards(
                _slider.value,
                _targetValue,
                _speed * Time.deltaTime
            );

            Debug.Log(_slider.value);
            yield return null;
        }

        _slider.value = _targetValue;
    }
}