using System;
using Unity.TDD.Abstracts.Combats;
using Unity.TDD.Abstracts.Controller;
using Unity.TDD.Controllers;
using UnityEngine;

namespace TDDBeginner.Combats
{
    public class EnemyController : MonoBehaviour, IEnemyController
    {
        public IAttacker Attacker { get; private set; }

        void Awake()
        {
            Attacker = new Attacker();
        }

        void OnCollisionEnter2D(Collision2D other)
        {
            if (other.collider.TryGetComponent(out IPlayerController playerController))
            {
                Debug.Log("Attack to player");
                playerController.Health.TakeDamage(Attacker);
            }
        }
    }
}