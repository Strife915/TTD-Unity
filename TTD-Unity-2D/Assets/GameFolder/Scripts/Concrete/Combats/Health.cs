using System;
using TDDBeginner.Combats;
using Unity.TDD.Abstracts.Combats;
using Unity.TDD.Abstracts.ScriptableObjects;
using UnityEngine;

namespace GameFolder.Scripts.Concretes.Combats
{
    public class Health : IHealth
    {
        int _currentHealth = 0;
        int _maxHealth = 0;
        public int CurrentHealth => _currentHealth;
        public bool Isdead => _currentHealth <= 0;
        public event Action OnTookDamage;
        public event Action OnDead;

        public Health(IStats stats)
        {
            _maxHealth = stats.MaxHealth;
            _currentHealth = _maxHealth;
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