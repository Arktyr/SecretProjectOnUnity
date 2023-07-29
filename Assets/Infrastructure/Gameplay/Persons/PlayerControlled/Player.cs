using System;
using Infrastructure.CodeBase.Services.InputService.Base;
using Infrastructure.Gameplay.Persons.AnyCharacter;
using Infrastructure.Gameplay.Persons.Common.Abilities;
using Infrastructure.Gameplay.Persons.PlayerControlled.CameraControl;
using Infrastructure.Gameplay.Persons.PlayerControlled.StateMachine;
using Infrastructure.Gameplay.Persons.PlayerControlled.StateMachine.States;
using IPlayerStateMachine = Infrastructure.Gameplay.Persons.PlayerControlled.StateMachine.IPlayerStateMachine;

namespace Infrastructure.Gameplay.Persons.PlayerControlled
{
    public class Player : IDisposable
    {
        private readonly IInputService _inputService;

        private ICharacter _character;
        private IAbility _ability;
        private IPlayerStateMachine _stateMachine;
        
        private PlayerCamera _playerCamera;

        public Player(IInputService inputService)
        {
            _inputService = inputService;
        }
        
        public void Construct(ICharacter character,
            IAbility ability,
            IPlayerStateMachine stateMachine,
            PlayerCamera playerCamera)
        {
            _character = character;
            _ability = ability;
            _stateMachine = stateMachine;
            _playerCamera = playerCamera;
            
            SubscribeToEventsInServices();
        }

        private void SubscribeToEventsInServices()
        {
            _character.CharacterInjuring.Health.Died += Dispose;
            _inputService.PlayerMovementInput.InputHappened += SetRunPlayerState;
            _inputService.PlayerInput.Ability.Teleport.performed += context => _ability.Cast();
        }

        private void UnSubscribeToEventsInServices()
        {
            _inputService.PlayerMovementInput.InputHappened -= SetRunPlayerState;
        }
        
        private void SetRunPlayerState()
        {
            if (_stateMachine.CurrentState == PlayerStateType.IdlingState) _stateMachine.Enter<RunState>();
        }

        public void Dispose()
        {
            _character.CharacterInjuring.Health.Died -= Dispose;
            _playerCamera?.Dispose();
            UnSubscribeToEventsInServices();
        }
    }
}