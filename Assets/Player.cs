using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private Slider _slider;

    private float _minHealth = 10;
    private float _currentHealth;

    private void Start()
    {
        _currentHealth = _maxHealth;
        _slider.maxValue = _maxHealth;
        _slider.value = _currentHealth;
    }

    private void OnValidate()
    {
        if (_maxHealth < _minHealth)
        {
            _maxHealth = _minHealth;
        }
    }

    public void TakeDamage(float gamage)
    {
        _currentHealth = Mathf.MoveTowards(_currentHealth, _maxHealth, gamage);
        _slider.value = _currentHealth;
    }
}
