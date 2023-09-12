using System;
using Infrastructure.CodeBase.Services.InputService.Base;
using Infrastructure.CodeBase.Services.Update;
using UnityEngine;

namespace Infrastructure.CodeBase.Services.InputService.Mobile
{
    public class PlayerCameraMoveInput : IPlayerCameraMoveInput
    {
        public event Action<Vector2> InputCameraMoveHappened;
        public event Action InputCameraMoveEnded;

        private readonly PlayerInput _playerInput;
        private readonly IUpdaterService _updaterService;
        private readonly IInputWatcher _inputWatcher;

        private Vector2 _lastDirection;

        public PlayerCameraMoveInput(PlayerInput playerInput,
            IUpdaterService updaterService, 
            IInputWatcher inputWatcher)
        {
            _playerInput = playerInput;
            _updaterService = updaterService;
            _inputWatcher = inputWatcher;
            
            _playerInput.Camera.PrimaryTouchContact.started += context => MoveStart();
            _playerInput.Camera.PrimaryTouchContact.canceled += context => MoveEnd();
        }

        private void MoveEnd()
        {
            _updaterService.Update -= Move;
            InputCameraMoveEnded?.Invoke();
        }

        private void MoveStart() => _updaterService.Update += Move;

        private void Move(float time)
        {
            if (_inputWatcher.IsUsesMovementInput == false && _inputWatcher.IsUsesCameraInput == false)
            {
                Vector2 distance = _playerInput.Camera.PrimaryFingerPosition.ReadValue<Vector2>();
                
                InputCameraMoveHappened?.Invoke(distance);
            }
            else
                MoveEnd();
        }
    }
}