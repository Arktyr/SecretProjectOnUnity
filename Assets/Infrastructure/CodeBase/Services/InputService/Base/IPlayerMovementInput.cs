using System;
using UnityEngine;

namespace Infrastructure.CodeBase.Services.InputService.Base
{
    public interface IPlayerMovementInput
    {
        public event Action InputHappened;

        public void SetFixedJoystick(FixedJoystick fixedJoystick);
        
        Vector2 Input();
    }
}