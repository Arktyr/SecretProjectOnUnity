using System;
using UnityEngine;

namespace Infrastructure.CodeBase.Services.InputService.Base
{
    public interface IPlayerMovementInput
    {
        public event Action InputHappened;
        
        Vector2 Input();
    }
}