using System;
using UnityEngine;

namespace Infrastructure.CodeBase.Services.InputService.Base
{
    public interface IPlayerCameraMoveInput
    {
        public event Action<Vector2> InputCameraMoveHappened;

        public event Action InputCameraMoveEnded;
    }
}