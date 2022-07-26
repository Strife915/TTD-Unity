using NUnit.Framework;
using Unity.TDD.Abstracts.Controller;
using Unity.TDD.Abstracts.Movements;
using UnityEngine;
using UnityEngine.TestTools;
using NSubstitute;
using Unity.TDD.Abstracts.Inputs;
using Unity.TDD.Abstracts.ScriptableObjects;
using Unity.TDD.EditTests.Helpers;
using Unity.TDD.Movements;

namespace Unity.TDD.PlayModeTest
{
    public class player_movement
    {
        IPlayerController GetPlayer()
        {
            var playerController = EditModeHelper.GetPlayerController();
            playerController.Stats.MoveSpeed.Returns(5f);

            return playerController;
        }

        IMover GetMoverWithTranslate(IPlayerController playerController)
        {
            IMover mover = new PlayerMoveWithTranslate(playerController);
            return mover;
        }

        // A Test behaves as an ordinary method
        [Test]
        [TestCase(1f)]
        [TestCase(-1f)]
        public void move_10_meters_right_not_equal_start_position(float horizontalInputValue)
        {
            //Arrange
            var playerController = GetPlayer();
            var mover = GetMoverWithTranslate(playerController);
            Vector3 startPosition = playerController.transform.position;
            //Act
            playerController.InputReader.Horizontal.Returns(horizontalInputValue);
            for (int i = 0; i < 10; i++)
            {
                mover.Tick();
                mover.FixedTick();
            }

            //Assert
            Assert.AreNotEqual(startPosition, playerController.transform.position);
        }

        [Test]
        public void move_10_meters_right_end_position_greater_than_start_position()
        {
            //Arrange
            var playerController = GetPlayer();
            var mover = GetMoverWithTranslate(playerController);
            Vector3 startPosition = playerController.transform.position;
            //Act
            playerController.InputReader.Horizontal.Returns(1f);
            for (int i = 0; i < 10; i++)
            {
                mover.Tick();
                mover.FixedTick();
            }

            //Assert
            Assert.Greater(playerController.transform.position.x, startPosition.x);
        }

        [Test]
        public void move_10_meters_left_end_position_less_than_start_position()
        {
            //Arrange
            var playerController = GetPlayer();
            IMover mover = GetMoverWithTranslate(playerController);
            Vector3 startPosition = playerController.transform.position;
            //Act
            playerController.InputReader.Horizontal.Returns(-1f);
            for (int i = 0; i < 10; i++)
            {
                mover.Tick();
                mover.FixedTick();
            }

            //Assert
            Assert.Less(playerController.transform.position.x, startPosition.x);
        }
    }
}