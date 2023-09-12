using System;
using Infrastructure.CodeBase.Services.InputService.Base;
using Infrastructure.CodeBase.Services.Update;
using UnityEngine;

namespace Infrastructure.CodeBase.Services.InputService.Mobile
{
    public class PlayerCameraZoomInput : IPlayerCameraZoomInput
    {
        public event Action<float> InputZoomHappened;

        private readonly PlayerInput _playerInput;
        private readonly IInputWatcher _inputWatcher;
        private readonly IUpdaterService _updaterService;
        
        private float _previousDistance;
        
        private const float ZoomUp = -2;
        private const float ZoomDown = 2;
        
        public PlayerCameraZoomInput(IUpdaterService updaterService,
            IInputWatcher inputWatcher, 
            PlayerInput playerInput)
        {
            _updaterService = updaterService;
            _inputWatcher = inputWatcher;
            _playerInput = playerInput;
            
            _playerInput.Camera.SecondaryTouchContact.started += context => ZoomStart();
            _playerInput.Camera.SecondaryTouchContact.canceled += context => ZoomEnd();
        }

        private void ZoomEnd()
        {
            _inputWatcher.SetDisableIsUsesCameraInput();
            _updaterService.Update -= Zoom;
        }

        private void ZoomStart()
        {
            _updaterService.Update += Zoom;
        }

        private void Zoom(float time)
        {
            if (_inputWatcher.IsUsesMovementInput == false)
            {
                _inputWatcher.SetEnableIsUsesCameraInput();
            
                float distance = Vector2.Distance(_playerInput.Camera.PrimaryFingerPosition.ReadValue<Vector2>(),
                    _playerInput.Camera.SecondaryFingerPostion.ReadValue<Vector2>());
            
                if (distance > _previousDistance) 
                    InputZoomHappened?.Invoke(ZoomUp);
            
                else if (distance < _previousDistance) 
                    InputZoomHappened?.Invoke(ZoomDown);

                _previousDistance = distance;
                
            }
            else
                ZoomEnd();
        }
    }
}