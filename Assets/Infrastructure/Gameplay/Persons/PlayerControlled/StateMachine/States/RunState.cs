using Infrastructure.CodeBase.Services.InputService.Base;
using Infrastructure.CodeBase.Services.Update;
using Infrastructure.Gameplay.Persons.AnyCharacter;
using Vector2 = UnityEngine.Vector2;


namespace Infrastructure.Gameplay.Persons.PlayerControlled.StateMachine.States
{
    public class RunState : IPlayerState
    {
        private IPlayerStateMachine _playerStateMachine;
        
        private readonly IUpdaterService _updaterService;
        private readonly IInputService _inputService;

        private ICharacterMovement _characterMovement;
        private PlayerAnimator _playerAnimator;

        public RunState(IUpdaterService updaterService, IInputService inputService)
        {
            _updaterService = updaterService;
            _inputService = inputService;
        }

        public void Construct(
            IPlayerStateMachine playerStateMachine,
            ICharacterMovement characterMovement,
            PlayerAnimator playerAnimator)
        {
            _playerStateMachine = playerStateMachine;
            _characterMovement = characterMovement;
            _playerAnimator = playerAnimator;
        }
        
        
        public void Exit()
        {
            _updaterService.Update -= Update;
            _playerAnimator.SetRunAnimation(false);
        }

        public void Enter()
        {
            _updaterService.Update += Update;
            _playerAnimator.SetRunAnimation(true);
        }

        private void Update(float time)
        {
            Vector2 direction = _inputService.PlayerMovementInput.Input();
            
            _characterMovement.Move(direction);
            
            _characterMovement.Rotate(direction);
            
            if (direction.magnitude == 0) 
                _playerStateMachine.Enter<IdlingState>();
        }
    }
}