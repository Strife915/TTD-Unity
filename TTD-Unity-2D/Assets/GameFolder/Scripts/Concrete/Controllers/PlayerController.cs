using System;
using Unity.TDD.Abstracts.Controller;
using Unity.TDD.Abstracts.Inputs;
using Unity.TDD.Abstracts.Movements;
using Unity.TDD.Movements;
using UnityEngine;

namespace Unity.TDD.Controllers
{
    public class PlayerController : MonoBehaviour, IPlayerController
    {
        public IInputReader InputReader { get; set; }
        IMover _mover;

        void Awake()
        {
            _mover = new PlayerMoveWithTranslate(this);
        }

        void Update()
        {
            _mover.Tick();
        }

        void FixedUpdate()
        {
            _mover.FixedTick();
        }
    }
}