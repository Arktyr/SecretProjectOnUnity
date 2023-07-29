using System;

namespace Infrastructure.CodeBase.Services.InputService.Base
{
    public interface IPlayerCameraZoomInput
    {
        public event Action<float> InputZoomHappened;
    }
}