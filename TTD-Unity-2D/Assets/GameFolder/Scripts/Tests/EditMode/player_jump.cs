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
            IJumpDal jumpDal = Substitute.For<IJumpDal>();
            var playerJumpManager = new PlayerJumpManager(player, jumpDal);

            player.InputReader.Jump.Returns(true);
            playerJumpManager.Tick();
            playerJumpManager.FixedTick();

            jumpDal.Received().JumpProcess();
        }

        [Test]
        public void player_can_not_jump_one_time_if_can_jump_is_false()
        {
            var player = EditModeHelper.GetPlayerController();
            IJumpDal jumpDal = Substitute.For<IJumpDal>();
            var playerJumpManager = new PlayerJumpManager(player, jumpDal);

            player.InputReader.Jump.Returns(false);
            playerJumpManager.Tick();
            playerJumpManager.FixedTick();

            jumpDal.DidNotReceive().JumpProcess();
        }
    }
}