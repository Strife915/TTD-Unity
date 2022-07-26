﻿using Unity.TDD.Abstracts.Combats;
using Unity.TDD.Abstracts.ScriptableObjects;

namespace TDDBeginner.Combats
{
    public class Attacker : IAttacker
    {
        readonly IStats _stats;

        public int Damage => _stats.Damage;

        public Attacker(IStats stats)
        {
            _stats = stats;
        }
    }
}