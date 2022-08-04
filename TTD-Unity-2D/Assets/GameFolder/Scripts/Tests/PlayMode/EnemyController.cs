using System;
using GameFolder.Scripts.Concretes.Combats;
using TDDBeginner.ScriptAbleObjects;
using Unity.TDD.Abstracts.Combats;
using Unity.TDD.Abstracts.Controller;
using Unity.TDD.Abstracts.ScriptableObjects;
using Unity.TDD.Controllers;
using UnityEngine;

namespace TDDBeginner.Combats
{
    public class EnemyController : MonoBehaviour, IEnemyController
    {
        [SerializeField] EnemyStats _stats;
        public IAttacker Attacker { get; set; }
        public IEnemyStats Stats => _stats;
        public IHealth Health { get; private set; }

        void Awake()
        {
            Attacker = new Attacker(Stats);
            Health = new Health(_stats);
        }

        void OnCollisionEnter2D(Collision2D other)
        {
            if (other.collider.TryGetComponent(out IPlayerController playerController))
            {
                if(other.contacts[0].normal.y != 1) return;
                playerController.Health.TakeDamage(Attacker);
            }
        }
    }
}