using Unity.TDD.Abstracts.Controller;
using Unity.TDD.Abstracts.Movements;
using UnityEngine;

namespace Unity.TDD.Movements
{
    public class PlayerMoveWithTranslate : IMover
    {
        readonly IPlayerController _playerController;
        readonly Transform _transform;
        float _horizontalInput = 0f;

        public PlayerMoveWithTranslate(IPlayerController playerController)
        {
            _playerController = playerController;
            _transform = playerController.transform;
        }

        public void Tick()
        {
            _horizontalInput = _playerController.InputReader.Horizontal;
        }

        public void FixedTick()
        {
            _transform.Translate(
                _horizontalInput * (_playerController.Stats.MoveSpeed * Time.deltaTime) * Vector2.right);
        }
    }
}