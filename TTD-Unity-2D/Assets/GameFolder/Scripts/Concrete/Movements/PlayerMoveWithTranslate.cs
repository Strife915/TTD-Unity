using Unity.TDD.Abstracts.Controller;
using Unity.TDD.Abstracts.Movements;
using UnityEngine;

namespace Unity.TDD.Movements
{
    public class PlayerMoveWithTranslate : IMover
    {
        readonly IPlayerController _playerController;
        readonly Transform _transform;
        float _moveSpeed = 1f;
        float _horizontalInput = 0f;

        public PlayerMoveWithTranslate(IPlayerController playerController)
        {
            _playerController = playerController;
            _transform = playerController.Transform;
        }

        public void Tick()
        {
            _horizontalInput = _playerController.InputReader.Horizontal;
        }

        public void FixedTick()
        {
            _transform.Translate(Vector2.right * _horizontalInput);
        }
    }
}