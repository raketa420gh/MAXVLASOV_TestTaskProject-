using System;
using UnityEngine;

public class Health : MonoBehaviour, IHealth
{
    private int _maxHealth;
    private int _currentHealth;

    public event Action OnOver;

    public void Initialize(int maxHealth)
    {
        _maxHealth = maxHealth;
        _currentHealth = _maxHealth;
    }

    public void ChangeHealth(int value)
    {
        _currentHealth += value;

        if (_currentHealth > _maxHealth)
            _currentHealth = _maxHealth;

        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            
            OnOver?.Invoke();
        }
    }
}