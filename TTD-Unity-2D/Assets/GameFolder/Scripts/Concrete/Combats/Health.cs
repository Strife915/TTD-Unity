using System;
using Unity.TDD.Abstracts.Combats;
using UnityEngine;

namespace GameFolder.Scripts.Concretes.Combats
{
    public class Health : IHealth
    {
        int _currentHealth = 0;

        public int CurrentHealth => _currentHealth;
        public bool Isdead => _currentHealth <= 0;
        public event Action OnTookDamage;
        public event Action OnDead;

        public Health(int maxHealth)
        {
            _currentHealth = maxHealth;
        }


        public void TakeDamage(IAttacker attacker)
        {
            if (Isdead) return;
            _currentHealth -= attacker.Damage;
            _currentHealth = Mathf.Max(_currentHealth, 0);
            OnTookDamage?.Invoke();

            if (Isdead)
            {
                OnDead?.Invoke();
            }
        }
    }
}