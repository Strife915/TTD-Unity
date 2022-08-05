using Unity.TDD.Abstracts.ScriptableObjects;
using UnityEngine;


namespace TDDBeginner.ScriptAbleObjects
{
    [CreateAssetMenu(fileName = "Player Stats", menuName = "bıdıbıdı/Stats/Player Stats")]
    public class PlayerStats : Stats, IPlayerStats
    {
        [SerializeField] float _jumpForce;

        public float JumpForce => _jumpForce;
        //public int Damage { get; }
    }
}