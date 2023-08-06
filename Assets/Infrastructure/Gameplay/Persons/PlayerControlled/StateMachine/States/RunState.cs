using Infrastructure.CodeBase.Services.InputService.Base;
using Infrastructure.CodeBase.Services.Update;
using Infrastructure.Gameplay.Persons.AnyCharacter;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;


namespace Infrastructure.Gameplay.Persons.PlayerControlled.StateMachine.States
{
    public class RunState : IPlayerState
    {
        private IPlayerStateMachine _playerStateMachine;
        
        private readonly IUpdaterService _updaterService;
        private readonly IInputService _inputService;

        private ICharacterMovement _characterMovement;
        private CharacterAnimator _characterAnimator;

        public RunState(IUpdaterService updaterService, IInputService inputService)
        {
            _updaterService = updaterService;
            _inputService = inputService;
        }

        public void Construct(
            IPlayerStateMachine playerStateMachine,
            ICharacterMovement characterMovement,
            CharacterAnimator characterAnimator)
        {
            _playerStateMachine = playerStateMachine;
            _characterMovement = characterMovement;
            _characterAnimator = characterAnimator;
        }
        
        
        public void Exit()
        {
            _characterAnimator.SetRunAnimation(false);
            _updaterService.FixedUpdate -= Update;
        }

        public void Enter()
        {
            _characterAnimator.SetRunAnimation(true);
            _updaterService.FixedUpdate += Update;
        }

        private void Update(float time)
        {
            Vector2 direction = _inputService.PlayerMovementInput.Input();

            Vector3 currentDirection = new Vector3(direction.x, 0, direction.y);
            
            _characterMovement.Move(currentDirection);
            
            _characterMovement.Rotate(currentDirection);
            
            if (direction.magnitude == 0) 
                _playerStateMachine.Enter<IdlingState>();
        }
    }
}