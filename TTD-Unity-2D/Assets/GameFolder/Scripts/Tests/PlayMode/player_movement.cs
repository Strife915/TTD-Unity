using NUnit.Framework;
using Unity.TDD.Abstracts.Controller;
using Unity.TDD.Abstracts.Movements;
using UnityEngine;
using UnityEngine.TestTools;
using NSubstitute;
using Unity.TDD.Abstracts.Inputs;
using Unity.TDD.Movements;

namespace Unity.TDD.PlayModeTest
{
    public class player_movement
    {
        // A Test behaves as an ordinary method
        [Test]
        public void move_10_meters_right_not_equal_start_position()
        {
            //Arrange
            IPlayerController playerController = Substitute.For<IPlayerController>();
            GameObject gameObject = new GameObject();
            playerController.Transform.Returns(gameObject.transform);
            playerController.InputReader = Substitute.For<IInputReader>();
            IMover mover = new PlayerMoveWithTranslate(playerController);
            Vector3 startPosition = playerController.Transform.position;
            //Act
            playerController.InputReader.Horizontal.Returns(1f);
            for (int i = 0; i < 10; i++)
            {
                mover.Tick();
                mover.FixedTick();
            }

            //Assert
            Assert.AreNotEqual(startPosition, playerController.Transform.position);
        }

        [Test]
        public void move_10_meters_right_end_position_greater_than_start_position()
        {
            //Arrange
            IPlayerController playerController = Substitute.For<IPlayerController>();
            GameObject gameObject = new GameObject();
            playerController.Transform.Returns(gameObject.transform);
            playerController.InputReader = Substitute.For<IInputReader>();
            IMover mover = new PlayerMoveWithTranslate(playerController);
            Vector3 startPosition = playerController.Transform.position;
            //Act
            playerController.InputReader.Horizontal.Returns(1f);
            for (int i = 0; i < 10; i++)
            {
                mover.Tick();
                mover.FixedTick();
            }

            //Assert
            Assert.Greater(playerController.Transform.position.x, startPosition.x);
        }

        [Test]
        public void move_10_meters_left_not_equal_start_position()
        {
            //Arrange
            IPlayerController playerController = Substitute.For<IPlayerController>();
            GameObject gameObject = new GameObject();
            playerController.Transform.Returns(gameObject.transform);
            playerController.InputReader = Substitute.For<IInputReader>();
            IMover mover = new PlayerMoveWithTranslate(playerController);
            Vector3 startPosition = playerController.Transform.position;
            //Act
            playerController.InputReader.Horizontal.Returns(-1f);
            for (int i = 0; i < 10; i++)
            {
                mover.Tick();
                mover.FixedTick();
            }

            //Assert
            Assert.AreNotEqual(startPosition, playerController.Transform.position);
        }

        [Test]
        public void move_10_meters_left_end_position_less_than_start_position()
        {
            //Arrange
            IPlayerController playerController = Substitute.For<IPlayerController>();
            GameObject gameObject = new GameObject();
            playerController.Transform.Returns(gameObject.transform);
            playerController.InputReader = Substitute.For<IInputReader>();
            IMover mover = new PlayerMoveWithTranslate(playerController);
            Vector3 startPosition = playerController.Transform.position;
            //Act
            playerController.InputReader.Horizontal.Returns(-1f);
            for (int i = 0; i < 10; i++)
            {
                mover.Tick();
                mover.FixedTick();
            }

            //Assert
            Assert.Less(playerController.Transform.position.x, startPosition.x);
        }
    }
}