using Unity.TDD.Abstracts.Combats;
using Unity.TDD.Abstracts.Inputs;
using Unity.TDD.Abstracts.ScriptableObjects;

namespace Unity.TDD.Abstracts.Controller
{
    public interface IPlayerController : IEntityController
    {
        IInputReader InputReader { get; set; }
        IAttacker Attacker { get; }
        IPlayerStats Stats { get; }
        IHealth Health { get; }
    }
}