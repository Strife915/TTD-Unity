using Unity.TDD.Abstracts.Controller;

namespace Unity.TDD.Movements
{
    public class PlayerJumpManager : IJumpService
    {
        readonly IPlayerController _playerController;
        readonly IJumpDal _jumpDal;
        bool _canJump;

        public PlayerJumpManager(IPlayerController playerController, IJumpDal jumpDal)
        {
            _playerController = playerController;
            _jumpDal = jumpDal;
        }

        public void Tick()
        {
            if (_playerController.InputReader.Jump)
            {
                _canJump = true;
                _jumpDal.JumpProcess();
            }
        }

        public void FixedTick()
        {
            if (_canJump)
            {
                _jumpDal.JumpProcess();
            }

            _canJump = false;
        }
    }
}