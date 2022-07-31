using System.Collections;
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
        IPlayerController _playerController;

        [UnitySetUp]
        public IEnumerator SetUp()
        {
            yield return SceneManager.LoadSceneAsync("PlayerMovementTest");
            _playerController = GameObject.FindObjectOfType<PlayerController>();
            _playerController.InputReader = Substitute.For<IInputReader>();
        }

        [UnityTest]
        [TestCase(1f, ExpectedResult = (IEnumerator)null)]
        [TestCase(-1f, ExpectedResult = (IEnumerator)null)]
        public IEnumerator input_value_1_player_scale_x_result_equal_1(float horizontalInput)
        {
            //Arrange


            //Act
            _playerController.InputReader.Horizontal.Returns(horizontalInput);
            yield return new WaitForSeconds(3f);
            //Assert
            Assert.AreEqual(_playerController.transform.GetChild(0).localScale.x, horizontalInput);
        }

        [UnityTest]
        [TestCase(1f, ExpectedResult = (IEnumerator)null)]
        [TestCase(-1f, ExpectedResult = (IEnumerator)null)]
        public IEnumerator player_scale_x_result_stop_and_input_came_zero(float horizontalInput)
        {
            //Arrange

            float firstInputValue = horizontalInput;

            float firstValue = horizontalInput;
            //Act
            _playerController.InputReader.Horizontal.Returns(horizontalInput);
            yield return new WaitForSeconds(3f);

            horizontalInput = 0;
            _playerController.InputReader.Horizontal.Returns(horizontalInput);

            yield return new WaitForSeconds(3f);

            //Assert
            Assert.AreEqual(firstValue, _playerController.transform.GetChild(0).transform.localScale.x);
        }
    }
}