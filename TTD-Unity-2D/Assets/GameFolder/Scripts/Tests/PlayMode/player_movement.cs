using System.Collections;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using Unity.TDD.Abstracts.Inputs;
using Unity.TDD.Controllers;
using UnityEngine;
using UnityEngine.TestTools;

public class player_movement
{
    [UnityTest]
    [TestCase(1f, ExpectedResult = (IEnumerator)null)]
    [TestCase(-1f, ExpectedResult = (IEnumerator)null)]
    public IEnumerator player_move_left_or_right_not_equal_start_position(float inputValue)
    {
        //Arrange
        GameObject playerObject = new GameObject("Player");
        var playerController = playerObject.AddComponent<PlayerController>();
        playerController.InputReader = Substitute.For<IInputReader>();
        Vector3 startPosition = playerController.Transform.position;

        //Act
        playerController.InputReader.Horizontal.Returns(inputValue);
        yield return new WaitForSeconds(5f);
        //Assert
        Assert.AreNotEqual(startPosition, playerController.Transform.position);
    }
}