using Unity.TDD.Abstracts.ScriptableObjects;
using UnityEngine;

namespace TDDBeginner.ScriptAbleObjects
{
    [CreateAssetMenu(fileName = "Enemy Stats", menuName = "bıdıbıdı/Stats/Enemy Stats")]
    public class EnemyStats : Stats, IEnemyStats
    {
    }
}