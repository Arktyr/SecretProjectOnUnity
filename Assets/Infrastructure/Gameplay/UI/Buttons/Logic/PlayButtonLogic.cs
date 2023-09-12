using Cysharp.Threading.Tasks;
using Infrastructure.CodeBase.General.StateMachine.Interfaces;
using Infrastructure.GameFSM;
using Infrastructure.Gameplay.UI.Windows;
using Infrastructure.Gameplay.UI.Windows.LoadScreen;
using Infrastructure.Providers.Windows;
using Infrastructure.SceneManagement;

namespace Infrastructure.CodeBase.UI.Buttons
{
    public class PlayButtonLogic
    {
        private readonly ISceneSwitcher _sceneSwitcher;
        private readonly IStateMachine _stateMachine;
        private readonly IWindowUIProvider _windowUIProvider;

        public PlayButtonLogic(ISceneSwitcher sceneSwitcher, 
            IStateMachine stateMachine,
            IWindowUIProvider windowUIProvider)
        {
            _sceneSwitcher = sceneSwitcher;
            _stateMachine = stateMachine;
            _windowUIProvider = windowUIProvider;
        }

        public async void Play()
        {
            await EnableLoadScreen();
            
            await _sceneSwitcher.LoadScene(SceneType.LevelScene);
           
            _stateMachine.Enter<LevelInitializationState>();
        }

        private async UniTask EnableLoadScreen()
        {
            LoadScreenLogic loadScreen = await _windowUIProvider.GetLoadScreenWindowFromProvider();
            
            loadScreen.ResetAlphaColor();

            await loadScreen.Enable();
        }
    }
}