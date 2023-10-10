using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectHealth : MonoBehaviour, IDamageable
{
    public float _maxHealth;
    public float _currentHealth;
    [SerializeField] protected UnityEvent onEndedHealth;
    protected virtual void Start()
    {
        _currentHealth = _maxHealth;
    }
    public virtual void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            onEndedHealth.Invoke();
        }
    }

    public void AddHealth(int value)
    {
        if (value > 0)
        {
            _currentHealth += value;
        }
        if (_currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }
    }
    protected float GetCurrenHealth()
    {
        return _currentHealth;
    }

}
