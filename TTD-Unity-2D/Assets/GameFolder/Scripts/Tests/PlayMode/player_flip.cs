using System.Collections;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using Unity.TDD.Abstracts.Controller;
using Unity.TDD.Abstracts.Inputs;
using Unity.TDD.Controllers;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace Unity.TDD.Movements
{
    public class player_flip
    {
        [UnityTest]
        [TestCase(1f, ExpectedResult = (IEnumerator)null)]
        [TestCase(-1f, ExpectedResult = (IEnumerator)null)]
        public IEnumerator input_value_1_player_scale_x_result_equal_1(float horizontalInput)
        {
            //Arrange
            yield return SceneManager.LoadSceneAsync("PlayerMovementTest");
            IPlayerController playerController = GameObject.FindObjectOfType<PlayerController>();
            playerController.InputReader = Substitute.For<IInputReader>();

            //Act
            playerController.InputReader.Horizontal.Returns(horizontalInput);
            yield return new WaitForSeconds(3f);
            //Assert
            Assert.AreEqual(playerController.transform.GetChild(0).localScale.x, horizontalInput);
        }

        [UnityTest]
        [TestCase(1f, ExpectedResult = (IEnumerator)null)]
        [TestCase(-1f, ExpectedResult = (IEnumerator)null)]
        public IEnumerator player_scale_x_result_stop_and_input_came_zero(float horizontalInput)
        {
            //Arrange
            yield return SceneManager.LoadSceneAsync("PlayerMovementTest");
            IPlayerController playerController = GameObject.FindObjectOfType<PlayerController>();
            playerController.InputReader = Substitute.For<IInputReader>();
            float firstInputValue = horizontalInput;

            float firstValue = horizontalInput;
            //Act
            playerController.InputReader.Horizontal.Returns(horizontalInput);
            yield return new WaitForSeconds(3f);

            horizontalInput = 0;
            playerController.InputReader.Horizontal.Returns(horizontalInput);

            yield return new WaitForSeconds(3f);

            //Assert
            Assert.AreEqual(firstValue, playerController.transform.GetChild(0).transform.localScale.x);
        }
    }
}