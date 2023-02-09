using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private float _maxHealth;

    private float _currentHealth;
    public Action HealthChenged;

    public float CurrentHealth => _currentHealth;
    public float MaxHealth => _maxHealth;


    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    private void OnValidate()
    {
        if (_maxHealth < 0)
        {
            _maxHealth = 0;
        }
    }

    public void TakeDamage(float damage)
    {
        if (damage > 0)
        {
            _currentHealth = Mathf.MoveTowards(_currentHealth, 0, damage);
            HealthChenged?.Invoke();
        }
    }

    public void TakeHeal(float heal)
    {
        if (heal > 0)
        {
            _currentHealth = Mathf.MoveTowards(_currentHealth, _maxHealth, heal);
            HealthChenged?.Invoke();
        }
    }
}
