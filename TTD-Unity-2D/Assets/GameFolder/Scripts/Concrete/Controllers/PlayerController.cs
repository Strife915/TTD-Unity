using System;
using GameFolder.Scripts.Concretes.Combats;
using TDDBeginner.Inputs;
using TDDBeginner.ScriptAbleObjects;
using Unity.TDD.Abstracts.Combats;
using Unity.TDD.Abstracts.Controller;
using Unity.TDD.Abstracts.Inputs;
using Unity.TDD.Abstracts.Movements;
using Unity.TDD.Abstracts.ScriptableObjects;
using Unity.TDD.Movements;
using UnityEngine;

namespace Unity.TDD.Controllers
{
    public class PlayerController : MonoBehaviour, IPlayerController
    {
        [SerializeField] PlayerStats _playerStats;
        public IInputReader InputReader { get; set; }
        public IPlayerStats Stats => _playerStats;
        public IHealth Health { get; private set; }

        IMover _mover;
        IFlip _flip;

        void Awake()
        {
            InputReader = new InputReader();
            _mover = new PlayerMoveWithTranslate(this);
            _flip = new PlayerFlipWithScale(this);
            Health = new Health(Stats);
        }

        void Update()
        {
            _mover.Tick();
            _flip.Tick();
        }

        void FixedUpdate()
        {
            _mover.FixedTick();
        }

        void OnCollisionEnter2D(Collision2D other)
        {
            //Debug.Log(nameof(OnCollisionEnter2D));
            if (other.collider.TryGetComponent(out IEnemyController enemyController))
            {
            }
        }
    }
}