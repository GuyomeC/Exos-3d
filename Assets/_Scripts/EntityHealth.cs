using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityHealth : MonoBehaviour
{
    [SerializeField] int _maxHealth;

    public event Action<int> OnHealthChanged;


    public int CurrentHealth { get; private set; }

    private void Awake()
    {
        CurrentHealth = _maxHealth;
    }

    public void RemoveHealth(int _damage)
    {
        if (CurrentHealth > _damage)
        {
            CurrentHealth -= _damage;
            OnHealthChanged?.Invoke(CurrentHealth);
        }
        else
        {
            CurrentHealth = 0;
            OnHealthChanged?.Invoke(CurrentHealth);

            Destroy(gameObject);
        }
    }
    
    
    public void AddHealth(int _health)
    {
        if (CurrentHealth > 0 )
        {
            CurrentHealth += _health;
            if (CurrentHealth < _maxHealth)
            {
                OnHealthChanged?.Invoke(CurrentHealth);
            }
            else
            {
                CurrentHealth = _maxHealth;
                OnHealthChanged?.Invoke(CurrentHealth);
            }

        }
    }


}
