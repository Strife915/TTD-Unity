using NSubstitute;
using Unity.TDD.Abstracts.Controller;
using Unity.TDD.Abstracts.Inputs;
using Unity.TDD.Abstracts.ScriptableObjects;
using UnityEngine;

namespace Unity.TDD.EditTests.Helpers
{
    public static class EditModeHelper
    {
        public static IPlayerController GetPlayerController()
        {
            IPlayerController playerController = Substitute.For<IPlayerController>();
            GameObject gameObject = new GameObject();
            playerController.transform.Returns(gameObject.transform);
            playerController.InputReader = Substitute.For<IInputReader>();
            playerController.Stats.Returns(Substitute.For<IPlayerStats>());

            return playerController;
        }
    }
}