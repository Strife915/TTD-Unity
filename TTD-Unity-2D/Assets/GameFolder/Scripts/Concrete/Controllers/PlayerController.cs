using Unity.TDD.Abstracts.Controller;
using Unity.TDD.Abstracts.Inputs;
using UnityEngine;

namespace Unity.TDD.Controllers
{
    public class PlayerController : MonoBehaviour, IPlayerController
    {
        public Transform Transform { get; }
        public IInputReader InputReader { get; set; }
    }
}