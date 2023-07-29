
using Infrastructure.Instatiator;

namespace Infrastructure.CodeBase.Services.InputService.Base
{
    public interface IInputService
    {
        public PlayerInput PlayerInput { get; }
        
        public IPlayerMovementInput PlayerMovementInput { get; }
        
        public IPlayerCameraZoomInput PlayerCameraZoomInput { get;  }
        
        public IPlayerCameraMoveInput PlayerCameraMoveInput { get;  }

        public void Init();

        public void InputEnable();
        
        public void InputDisable();
    }
}