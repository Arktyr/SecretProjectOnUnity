using Infrastructure.Gameplay.Persons.AnyCharacter;

namespace Infrastructure.Gameplay.Persons.PlayerControlled.StateMachine.States
{
    public class IdlingState : IPlayerState
    {
        private CharacterAnimator _characterAnimator;

        public void Construct(CharacterAnimator characterAnimator)
        {
            _characterAnimator = characterAnimator;
        }
        
        public void Exit()
        {
            _characterAnimator.SetIdleAnimation(false);
        }

        public void Enter()
        {
            _characterAnimator.SetIdleAnimation(true);
        }
    }
}