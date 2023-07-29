using Infrastructure.CodeBase.Services.InputService.Base;
using Infrastructure.CodeBase.Services.Update;
using Infrastructure.Instatiator;

namespace Infrastructure.CodeBase.Services.InputService.Mobile
{
    public class InputService : IInputService
    {
        public PlayerInput PlayerInput { get; private set; }
        public IPlayerMovementInput PlayerMovementInput { get; private set; }
        public IPlayerCameraZoomInput PlayerCameraZoomInput { get; private set; }
        public IPlayerCameraMoveInput PlayerCameraMoveInput { get; private set; }

        private readonly IInputWatcher _inputWatcher;
        private readonly IUpdaterService _updaterService;
        
        public InputService(IUpdaterService updaterService,
            IInputWatcher inputWatcher)
        {
            _inputWatcher = inputWatcher;
            _updaterService = updaterService;
        }
        
        public void Init()
        {
            PlayerInput = new PlayerInput();
            
            PlayerMovementInput = new PlayerMovementInput(_updaterService, _inputWatcher);

            PlayerCameraZoomInput = new PlayerCameraZoomInput(_updaterService, _inputWatcher, PlayerInput);
            
            PlayerCameraMoveInput = new PlayerCameraMoveInput(PlayerInput, _updaterService, _inputWatcher);
        }

        public void InputEnable() => PlayerInput.Enable();

        public void InputDisable() => PlayerInput.Disable();
    }
}