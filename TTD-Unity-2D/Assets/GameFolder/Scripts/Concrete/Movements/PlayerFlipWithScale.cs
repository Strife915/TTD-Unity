using Unity.TDD.Abstracts.Controller;
using Unity.TDD.Abstracts.Movements;
using UnityEngine;

namespace Unity.TDD.Movements
{
    public class PlayerFlipWithScale : IFlip
    {
        readonly Transform _transform;
        readonly IPlayerController _playerController;


        public PlayerFlipWithScale(IPlayerController playerController)
        {
            _transform = playerController.transform.GetChild(0).transform;
            _playerController = playerController;
        }

        public void Tick()
        {
            float horizontalInput = _playerController.InputReader.Horizontal;
            if (horizontalInput == 0f) return;
            _transform.localScale = new Vector3(horizontalInput, 1f, 1f);
        }
    }
}