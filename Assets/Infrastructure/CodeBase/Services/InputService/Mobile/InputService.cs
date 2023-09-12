using Infrastructure.CodeBase.Services.InputService.Base;
using Infrastructure.CodeBase.Services.Update;
using Infrastructure.Instatiator;
using Infrastructure.Providers;

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
        private readonly IUIProvider _uiProvider;
        
        public InputService(IUpdaterService updaterService,
            IInputWatcher inputWatcher,
            IUIProvider uiProvider)
        {
            _inputWatcher = inputWatcher;
            _updaterService = updaterService;
            _uiProvider = uiProvider;
        }
        
        public void Init()
        {
            PlayerInput = new PlayerInput();
            
            PlayerMovementInput = new PlayerMovementInput(_updaterService, _inputWatcher, _uiProvider);

            PlayerCameraZoomInput = new PlayerCameraZoomInput(_updaterService, _inputWatcher, PlayerInput);
            
            PlayerCameraMoveInput = new PlayerCameraMoveInput(PlayerInput, _updaterService, _inputWatcher);
        }

        public void InputEnable() => PlayerInput.Enable();

        public void InputDisable() => PlayerInput.Disable();
    }
}