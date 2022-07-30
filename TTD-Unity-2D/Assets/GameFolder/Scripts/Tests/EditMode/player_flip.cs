using NSubstitute;
using NUnit.Framework;
using Unity.TDD.Abstracts.Controller;
using Unity.TDD.Abstracts.Inputs;
using Unity.TDD.Abstracts.Movements;
using UnityEngine;

namespace Unity.TDD.Movements
{
    public class player_flip : MonoBehaviour
    {
        [Test]
        [TestCase(1f)]
        [TestCase(-1f)]
        public void player_scale_x_result_equal(float horizontalInput)
        {
            //Arrange
            IPlayerController playerController = Substitute.For<IPlayerController>();
            GameObject parent = new GameObject();
            GameObject body = new GameObject();
            body.transform.SetParent(parent.transform);
            playerController.transform.Returns(parent.transform);
            playerController.InputReader.Returns(Substitute.For<IInputReader>());
            playerController.InputReader.Horizontal.Returns(horizontalInput);
            IFlip flip = new PlayerFlipWithScale(playerController);
            //Act
            for (int i = 0; i < 10; i++)
            {
                flip.Tick();
            }

            //Assert
            Assert.AreEqual(horizontalInput, body.transform.localScale.x);
        }

        [Test]
        [TestCase(1f)]
        [TestCase(-1f)]
        public void player_scale_x_result_stop_and_input_came_zero(float horizontalInput)
        {
            //Arrange
            IPlayerController playerController = Substitute.For<IPlayerController>();
            GameObject parent = new GameObject();
            GameObject body = new GameObject();
            body.transform.SetParent(parent.transform);
            playerController.transform.Returns(parent.transform);
            playerController.InputReader.Returns(Substitute.For<IInputReader>());
            playerController.InputReader.Horizontal.Returns(horizontalInput);

            IFlip flip = new PlayerFlipWithScale(playerController);
            float firstValue = horizontalInput;
            //Act
            for (int i = 0; i < 10; i++)
            {
                flip.Tick();
            }

            horizontalInput = 0;
            playerController.InputReader.Horizontal.Returns(horizontalInput);

            for (int i = 0; i < 10; i++)
            {
                flip.Tick();
            }

            //Assert
            Assert.AreEqual(firstValue, body.transform.localScale.x);
        }
    }
}