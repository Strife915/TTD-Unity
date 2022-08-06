using NSubstitute;
using NUnit.Framework;
using Unity.TDD.EditTests.Helpers;
using UnityEngine;

namespace Unity.TDD.Movements
{
    public class player_jump : MonoBehaviour
    {
        [Test]
        public void player_jump_one_time_if_can_jump_is_true()
        {
            var player = EditModeHelper.GetPlayerController();
            player.Stats.JumpForce.Returns(10000);
            var rigidBody = player.transform.gameObject.AddComponent<Rigidbody2D>();
            var playerJump = new PlayerForceJump(player);

            float initialJumpForce = playerJump.JumpForce;

            for (int i = 0; i < 10; i++)
            {
                player.InputReader.Jump.Returns(true);
                playerJump.Tick();
                playerJump.FixedTick();
            }

            Assert.Greater(playerJump.JumpForce, initialJumpForce);
        }

        [Test]
        public void player_can_not_jump_one_time_if_can_jump_is_false()
        {
            var player = EditModeHelper.GetPlayerController();
            player.Stats.JumpForce.Returns(10000);
            var rigidBody = player.transform.gameObject.AddComponent<Rigidbody2D>();
            var playerJump = new PlayerForceJump(player);

            float initialJumpForce = playerJump.JumpForce;

            for (int i = 0; i < 10; i++)
            {
                player.InputReader.Jump.Returns(false);
                playerJump.Tick();
                playerJump.FixedTick();
            }

            Assert.AreEqual(initialJumpForce, playerJump.JumpForce);
        }
    }
}