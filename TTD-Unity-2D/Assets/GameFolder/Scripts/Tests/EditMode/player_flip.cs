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
        IPlayerController GetPlayer(float horizontalInput)
        {
            IPlayerController playerController = Substitute.For<IPlayerController>();
            GameObject parent = new GameObject();
            GameObject body = new GameObject();
            body.transform.SetParent(parent.transform);
            playerController.transform.Returns(parent.transform);
            playerController.InputReader.Returns(Substitute.For<IInputReader>());
            playerController.InputReader.Horizontal.Returns(horizontalInput);


            return playerController;
        }


        [Test]
        [TestCase(1f)]
        [TestCase(-1f)]
        public void player_scale_x_result_equal(float horizontalInput)
        {
            //Arrange
            var playerController = GetPlayer(horizontalInput);
            IFlip flip = new PlayerFlipWithScale(playerController);
            //Act
            for (int i = 0; i < 10; i++)
            {
                flip.Tick();
            }

            //Assert
            Assert.AreEqual(horizontalInput, playerController.transform.GetChild(0).transform.localScale.x);
        }

        [Test]
        [TestCase(1f)]
        [TestCase(-1f)]
        public void player_scale_x_result_stop_and_input_came_zero(float horizontalInput)
        {
            //Arrange
            var playerController = GetPlayer(horizontalInput);

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
            Assert.AreEqual(firstValue, playerController.transform.GetChild(0).transform.localScale.x);
        }
    }
}