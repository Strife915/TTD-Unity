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
        public void input_value_1_player_scale_x_result_equal_1(float horizontalInput)
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
    }
}