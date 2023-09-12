using System;
using Infrastructure.CodeBase.Services.InputService.Base;
using Infrastructure.CodeBase.Services.Update;
using Infrastructure.Providers;
using UnityEngine;

namespace Infrastructure.CodeBase.Services.InputService.Mobile
{
    public class PlayerMovementInput : IPlayerMovementInput
    {
        public event Action InputHappened;
        
        private readonly IInputWatcher _inputWatcher;
        private readonly IUpdaterService _updaterService;
        private readonly IUIProvider _uiProvider;
        
        private FixedJoystick _fixedJoystick;

        public PlayerMovementInput(IUpdaterService updaterService, 
            IInputWatcher inputWatcher,
            IUIProvider uiProvider)
        {
            _updaterService = updaterService;
            _inputWatcher = inputWatcher;
            _uiProvider = uiProvider;

            _updaterService.Update += InputWatch;
        }
        
        private async void InputWatch(float time)
        {
            _fixedJoystick = await _uiProvider.GetFixedJoystickFromProvider(); 
            
            if (_fixedJoystick != null && _fixedJoystick.Direction.magnitude > 0)
            {
                _inputWatcher.SetEnableIsUsesMovementInput();
                InputHappened?.Invoke();
            }
            else
                _inputWatcher.SetDisableIsUsesMovementInput();
        }
        
        public Vector2 Input() => _fixedJoystick.Direction;
    }
}