using Unity.TDD.Abstracts.ScriptableObjects;
using UnityEngine;


namespace TDDBeginner.ScriptAbleObjects
{
    [CreateAssetMenu(fileName = "Player Stats", menuName = "bıdıbıdı/Stats/Player Stats")]
    public class PlayerStats : ScriptableObject, IPlayerStats
    {
        [SerializeField] float _moveSpeed = 5f;
        public float MoveSpeed => _moveSpeed;
    }
}