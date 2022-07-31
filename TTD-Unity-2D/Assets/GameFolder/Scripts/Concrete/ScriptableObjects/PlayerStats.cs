using Unity.TDD.Abstracts.ScriptableObjects;
using UnityEngine;


namespace TDDBeginner.ScriptAbleObjects
{
    [CreateAssetMenu(fileName = "Player Stats", menuName = "bıdıbıdı/Stats/Player Stats")]
    public class PlayerStats : ScriptableObject, IPlayerStats
    {
        [Header("Move Information")] [SerializeField]
        float _moveSpeed = 5f;

        [Header("Combat Information")] [SerializeField]
        int _maxHealth;

        public float MoveSpeed => _moveSpeed;
        public int MaxHealth => _maxHealth;
    }
}