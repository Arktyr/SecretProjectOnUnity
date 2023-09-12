using Cysharp.Threading.Tasks;
using Infrastructure.CodeBase.General.StateMachine.Interfaces;
using Infrastructure.CodeBase.Services.Update;
using Infrastructure.GameFSM;
using Infrastructure.Gameplay.Spawner;
using Infrastructure.Gameplay.UI.Windows.LoadScreen;
using Infrastructure.Providers.Windows;
using Infrastructure.SceneManagement;
using UnityEngine;

namespace Infrastructure.Gameplay.UI.Buttons.Logic
{
    public class ReturnToMainMenuButtonLogic
    {
        private readonly IStateMachine _stateMachine;
        private readonly ISceneSwitcher _sceneSwitcher;
        private readonly IEnemyPool _enemyPool;
        private readonly IEnemySpawner _enemySpawner;
        private readonly IWindowUIProvider _windowUIProvider;

        public ReturnToMainMenuButtonLogic(IStateMachine stateMachine,
            ISceneSwitcher sceneSwitcher,
            IEnemyPool enemyPool,
            IEnemySpawner enemySpawner,
            IWindowUIProvider windowUIProvider)
        {
            _stateMachine = stateMachine;
            _sceneSwitcher = sceneSwitcher;
            _enemyPool = enemyPool;
            _enemySpawner = enemySpawner;
            _windowUIProvider = windowUIProvider;
        }

        public async void Return()
        {
            _enemySpawner.StopSpawnEnemies();
            _enemyPool.ClearPool();
            
            await EnableLoadScreen();
            
            Time.timeScale = 1;

            await _sceneSwitcher.LoadScene(SceneType.MainMenu);
            
            _stateMachine.Enter<MainMenuState>();
        }

        private async UniTask EnableLoadScreen()
        {
            LoadScreenLogic logic = await _windowUIProvider.GetLoadScreenWindowFromProvider();
            await logic.Enable();
        }
    }
}