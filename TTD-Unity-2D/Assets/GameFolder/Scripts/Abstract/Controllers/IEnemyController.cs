using Unity.TDD.Abstracts.Combats;
using Unity.TDD.Abstracts.ScriptableObjects;

namespace Unity.TDD.Abstracts.Controller
{
    public interface IEnemyController : IEntityController
    {
        IAttacker Attacker { get; set; }
        IEnemyStats Stats { get; }
    }
}