using Unity.TDD.Abstracts.Inputs;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TDDBeginner.Inputs
{
    public class InputReader : IInputReader
    {
        readonly GameInputActions _input;
        public float Horizontal { get; private set; }
        public bool Jump => _input.Player.Jump.WasPerformedThisFrame();

        public InputReader()
        {
            _input = new GameInputActions();
            _input.Player.Move.performed += HandleOnMoved;
            _input.Player.Move.canceled += HandleOnMoved;

            _input.Enable();
        }

        void HandleOnMoved(InputAction.CallbackContext context)
        {
            Horizontal = context.ReadValue<Vector2>().x;
        }
    }
}