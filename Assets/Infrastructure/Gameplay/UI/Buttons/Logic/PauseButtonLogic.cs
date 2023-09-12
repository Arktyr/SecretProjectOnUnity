using Cysharp.Threading.Tasks;
using Infrastructure.CodeBase.Services.Update;
using Infrastructure.Gameplay.UI.Windows;
using Infrastructure.Providers;
using Infrastructure.Providers.Windows;
using UnityEngine;

namespace Infrastructure.Factories.UIFactories.Buttons
{
    public class PauseButtonLogic
    {
        private readonly IUIProvider _uiProvider;
        private readonly IWindowUIProvider _windowUIProvider;
        private readonly IUpdaterService _updaterService;

        public PauseButtonLogic(IUIProvider uiProvider,
            IWindowUIProvider windowUIProvider,
            IUpdaterService updaterService)
        {
            _updaterService = updaterService;
            _uiProvider = uiProvider;
            _windowUIProvider = windowUIProvider;
        }

        public async void Pause()
        {
            _updaterService.StopTicking();
            Time.timeScale = 0;
            
            FixedJoystick fixedJoystick = await _uiProvider.GetFixedJoystickFromProvider();
            fixedJoystick.enabled = false;
            
            await OpenPauseMenu();
        }

        private async UniTask OpenPauseMenu()
        {
            IWindowLogic pauseMenu = await _windowUIProvider.GetPauseMenuWindowFromProvider();
            
            pauseMenu.Enable();
        }
    }
}