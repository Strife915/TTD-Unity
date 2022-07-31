﻿using Unity.TDD.Abstracts.Combats;
using Unity.TDD.Abstracts.Inputs;
using Unity.TDD.Abstracts.ScriptableObjects;

namespace Unity.TDD.Abstracts.Controller
{
    public interface IPlayerController : IEntityController
    {
        IInputReader InputReader { get; set; }
        IPlayerStats Stats { get; }
        IHealth Health { get; }
    }

    public interface IEnemyController : IEntityController
    {
        IAttacker Attacker { get; }
    }
}