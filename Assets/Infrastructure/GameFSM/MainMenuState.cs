using Cysharp.Threading.Tasks;
using DG.Tweening;
using Infrastructure.Addressable.Loader;
using Infrastructure.Addressable.WarmUp;
using Infrastructure.CodeBase.General.StateMachine.Interfaces;
using Infrastructure.Factories;
using Infrastructure.Gameplay.UI.Windows.LoadScreen;
using Infrastructure.Providers.MainMenu;
using Infrastructure.Providers.Windows;

namespace Infrastructure.GameFSM
{
    public class MainMenuState : IState
    {
        private readonly IMainMenuDataProvider _mainMenuDataProvider;
        private readonly IWindowUIProvider _windowUIProvider;
        
        public MainMenuState(IMainMenuDataProvider mainMenuDataProvider,
            IWindowUIProvider windowUIProvider)
        {
            _mainMenuDataProvider = mainMenuDataProvider;
            _windowUIProvider = windowUIProvider;
        }

        public void Exit()
        {
            DOTween.KillAll();
        }

        public async void Enter()
        {
            await WarmUp();

            await SpawnObjects();

            await DisableLoadScreen();
        }

        private async UniTask DisableLoadScreen()
        {
            LoadScreenLogic logic = await _windowUIProvider.GetLoadScreenWindowFromProvider();
            await logic.Disable();
        }
        
        private async UniTask SpawnObjects()
        {
            IMainMenuUIFactory mainMenuUIFactory = await _mainMenuDataProvider.GetMainMenuUIFactory();

            await mainMenuUIFactory.CreateMainMenu();
        }
        
        private async UniTask WarmUp()
        {
            IWarmUpper warmUpper = await _mainMenuDataProvider.GetMainMenuWarmUpper();

            await warmUpper.WarmUp();
        }
    }
}