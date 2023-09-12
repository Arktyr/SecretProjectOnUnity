using System;
using Infrastructure.CodeBase.Services.InputService.Base;
using Infrastructure.CodeBase.Services.Update;
using Infrastructure.Gameplay.Persons.AnyCharacter;
using Infrastructure.Gameplay.Persons.AnyCharacter.Abilities;
using Infrastructure.Gameplay.Persons.PlayerControlled.CameraControl;
using Infrastructure.Gameplay.Persons.PlayerControlled.StateMachine;
using Infrastructure.Gameplay.Persons.PlayerControlled.StateMachine.States;
using UnityEngine;
using IPlayerStateMachine = Infrastructure.Gameplay.Persons.PlayerControlled.StateMachine.IPlayerStateMachine;

namespace Infrastructure.Gameplay.Persons.PlayerControlled
{
    public class Player : IDisposable
    {
        private readonly IInputService _inputService;

        private ICharacter _character;
        private IPlayerStateMachine _stateMachine;
        
        private PlayerCamera _playerCamera;

        private readonly IUpdaterService _updaterService;
        
        public ICharacter Character => _character;

        public Player(IInputService inputService, 
            IUpdaterService updaterService)
        {
            _inputService = inputService;
            _updaterService = updaterService;
        }
        
        public void Construct(ICharacter character,
            IPlayerStateMachine stateMachine,
            PlayerCamera playerCamera)
        {
            _character = character;
            _stateMachine = stateMachine;
            _playerCamera = playerCamera;
            
            SubscribeToEventsInServices();
        }

        private void SubscribeToEventsInServices()
        {
            _character.DisposableService.OnDisposable += Dispose;
            _character.CharacterInjuring.Health.Died += Dispose;
            _inputService.PlayerMovementInput.InputHappened += SetRunPlayerState;
            _inputService.PlayerInput.Ability.Teleport.performed +=
                context => _character.CharacterAbility.TryUseSingleAbility<CharacterTeleportForward>();

            _updaterService.Update += Attack;
        }

        private void UnSubscribeToEventsInServices()
        {
            _character.DisposableService.OnDisposable -= Dispose;
            _character.CharacterInjuring.Health.Died -= Dispose;
            _inputService.PlayerMovementInput.InputHappened -= SetRunPlayerState;
          
            _updaterService.Update -= Attack;
        }

        private void Attack(float time) => _character.CharacterAbility.TryUseAllAbilitiesByType(AbilityType.Attack);

        private void SetRunPlayerState()
        {
            if (_stateMachine.CurrentState == PlayerStateType.IdlingState) _stateMachine.Enter<RunState>();
        }

        public void Dispose()
        {
            UnSubscribeToEventsInServices();
            _playerCamera?.Dispose();
        }
    }
}