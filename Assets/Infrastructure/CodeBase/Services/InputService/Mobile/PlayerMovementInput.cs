using System;
using Infrastructure.CodeBase.Services.InputService.Base;
using Infrastructure.CodeBase.Services.Update;
using UnityEngine;

namespace Infrastructure.CodeBase.Services.InputService.Mobile
{
    public class PlayerMovementInput : IPlayerMovementInput
    {
        public event Action InputHappened;
        
        private readonly IInputWatcher _inputWatcher;
        private readonly IUpdaterService _updaterService;
        
        private FixedJoystick _fixedJoystick;

        public PlayerMovementInput(IUpdaterService updaterService, IInputWatcher inputWatcher)
        {
            _updaterService = updaterService;
            _inputWatcher = inputWatcher;

            _updaterService.Update += InputWatch;
        }
        
        private void InputWatch(float time)
        {
            if (_fixedJoystick != null && _fixedJoystick.Direction.magnitude > 0)
            {
                _inputWatcher.SetIsUsesMovementInput(true);
                InputHappened?.Invoke();
            }
            else
                _inputWatcher.SetIsUsesMovementInput(false);
        }

        public void SetFixedJoystick(FixedJoystick fixedJoystick) => _fixedJoystick = fixedJoystick;

        public Vector2 Input() => _fixedJoystick.Direction;
    }
}