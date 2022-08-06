using System.Collections;
using NSubstitute;
using NUnit.Framework;
using TDDBeginner.Inputs;
using Unity.TDD.Abstracts.Inputs;
using Unity.TDD.Controllers;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class player_jump : MonoBehaviour
{
    [UnityTest]
    public IEnumerator player_jump_one_time()
    {
        yield return SceneManager.LoadSceneAsync("PlayerMovementTest");
        var player = GameObject.FindObjectOfType<PlayerController>();
        player.InputReader = Substitute.For<IInputReader>();

        yield return null;
        float yStartPosition = player.transform.position.y;

        player.InputReader.Jump.Returns(true);
        yield return null;
        player.InputReader.Jump.Returns(false);

        yield return new WaitForSeconds(2f);
        Assert.Greater(player.transform.position.y, yStartPosition);
    }

    [UnityTest]
    public IEnumerator player_jump_one_time_on_multiple_input()
    {
        yield return SceneManager.LoadSceneAsync("PlayerMovementTest");
        var player = GameObject.FindObjectOfType<PlayerController>();
        player.InputReader = Substitute.For<IInputReader>();

        yield return null;
        float yStartPosition = player.transform.position.y;

        player.InputReader.Jump.Returns(true);
        yield return null;

        yield return new WaitForSeconds(2f);
        Assert.LessOrEqual(player.transform.position.y, yStartPosition);
    }

    [UnityTest]
    public IEnumerator player_jump_one_time_wait_after_jump_again()
    {
        yield return SceneManager.LoadSceneAsync("PlayerMovementTest");
        var player = GameObject.FindObjectOfType<PlayerController>();
        player.InputReader = Substitute.For<IInputReader>();

        yield return null;
        float yStartPosition = player.transform.position.y;

        player.InputReader.Jump.Returns(true);
        yield return null;
        player.InputReader.Jump.Returns(false);


        yield return new WaitForSeconds(2f);

        player.InputReader.Jump.Returns(true);
        yield return null;
        player.InputReader.Jump.Returns(false);
        yield return new WaitForSeconds(1f);

        Assert.Greater(player.transform.position.y, yStartPosition);
    }
}