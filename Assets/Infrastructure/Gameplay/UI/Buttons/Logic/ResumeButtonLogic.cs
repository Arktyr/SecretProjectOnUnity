using Cysharp.Threading.Tasks;
using Infrastructure.CodeBase.Services.Update;
using Infrastructure.Gameplay.UI.Windows;
using Infrastructure.Providers;
using Infrastructure.Providers.Windows;
using UnityEngine;

namespace Infrastructure.Gameplay.UI.Buttons.Logic
{
    public class ResumeButtonLogic
    {
        private readonly IWindowUIProvider _windowUIProvider;
        private readonly IUIProvider _uiProvider;
        private readonly IUpdaterService _updaterService;

        public ResumeButtonLogic(IWindowUIProvider windowUIProvider,
            IUIProvider uiProvider,
            IUpdaterService updaterService)
        {
            _windowUIProvider = windowUIProvider;
            _uiProvider = uiProvider;
            _updaterService = updaterService;
        }

        public async void Resume()
        {
            await ClosePauseMenu();
            
            await EnableJoystick();
            
            Time.timeScale = 1;

            _updaterService.StartTicking();
        }

        private async UniTask EnableJoystick()
        {
            FixedJoystick fixedJoystick = await _uiProvider.GetFixedJoystickFromProvider();

            fixedJoystick.enabled = true;
        }

        private async UniTask ClosePauseMenu()
        {
            IWindowLogic pauseMenu = await _windowUIProvider.GetPauseMenuWindowFromProvider();
            
            pauseMenu.Disable();
        }
    }
}