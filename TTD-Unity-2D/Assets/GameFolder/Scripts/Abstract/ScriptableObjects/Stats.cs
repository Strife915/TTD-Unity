using UnityEngine;

namespace TDDBeginner.ScriptAbleObjects
{
    public abstract class Stats : ScriptableObject
    {
        [Header("Move Information")] [SerializeField]
        protected float _moveSpeed = 5f;

        [Header("Combat Information")] [SerializeField]
        protected int _maxHealth;
        [SerializeField] protected int _damage;
        public float MoveSpeed => _moveSpeed;
        public int MaxHealth => _maxHealth;
        public int Damage => _damage;
    }
}