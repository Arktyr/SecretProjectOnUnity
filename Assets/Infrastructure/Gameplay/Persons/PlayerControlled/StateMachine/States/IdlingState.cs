using Infrastructure.Gameplay.Persons.AnyCharacter;

namespace Infrastructure.Gameplay.Persons.PlayerControlled.StateMachine.States
{
    public class IdlingState : IPlayerState
    {
        private PlayerAnimator _playerAnimator;

        public void Construct(PlayerAnimator playerAnimator)
        {
            _playerAnimator = playerAnimator;
        }
        
        public void Exit()
        {
            _playerAnimator.SetIdleAnimation(false);
        }

        public void Enter()
        {
            _playerAnimator.SetIdleAnimation(true);
        }
    }
}