using TDDBeginner.Inputs;
using TDDBeginner.ScriptAbleObjects;
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
        IMover _mover;

        void Awake()
        {
            InputReader = new InputReader();
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