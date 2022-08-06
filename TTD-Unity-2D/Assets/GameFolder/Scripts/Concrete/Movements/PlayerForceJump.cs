﻿using Unity.TDD.Abstracts.Controller;
using UnityEngine;

namespace Unity.TDD.Movements
{
    public class PlayerForceJump : IJump
    {
        readonly IPlayerController _playerController;
        readonly Rigidbody2D _rigidbody2D;
        bool _canJump;

        public float JumpForce { get; private set; }

        public PlayerForceJump(IPlayerController playerController)
        {
            _playerController = playerController;
            _rigidbody2D = _playerController.transform.GetComponent<Rigidbody2D>();
        }

        public void Tick()
        {
            if (_playerController.InputReader.Jump)
            {
                _canJump = true;
            }
        }

        public void FixedTick()
        {
            if (_canJump)
            {
                JumpForce = _playerController.Stats.JumpForce * Time.deltaTime;
                _rigidbody2D.AddForce(JumpForce * Vector3.up);
            }
            else
            {
                JumpForce = 0;
            }

            _canJump = false;
        }
    }

    public interface IJump
    {
        void Tick();
        void FixedTick();
    }
}