using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Infrastructure.Addressable.Loader;
using Infrastructure.Addressable.WarmUp;
using Infrastructure.CodeBase.General.StateMachine.Interfaces;
using Infrastructure.CodeBase.Services.InputService.Base;
using Infrastructure.Creation;
using Infrastructure.Gameplay.UI.Windows;
using Infrastructure.Gameplay.UI.Windows.LoadScreen;
using Infrastructure.Providers;
using Infrastructure.Providers.Windows;
using UnityEngine;

namespace Infrastructure.GameFSM
{
    public class LevelInitializationState : IState
    {
        private readonly IStateMachine _stateMachine;
        private readonly ILevelDataProvider _levelDataProvider;
        private readonly IInputService _inputService;
        private readonly IWindowUIProvider _windowUIProvider;

        public LevelInitializationState(IStateMachine stateMachine,
            ILevelDataProvider levelDataProvider,
            IInputService inputService,
            IWindowUIProvider windowUIProvider)
        {
            _stateMachine = stateMachine;
            _levelDataProvider = levelDataProvider;
            _inputService = inputService;
            _windowUIProvider = windowUIProvider;
        }

        public async void Enter()
        {
            _inputService.Init();

            await WarmUp();

            await CreateLoadingScreen();
            
            await SpawnLevelObjects();
            
            await DisableLoadingScreen();
            
            _stateMachine.Enter<LevelState>();
        }

        public async void Exit()
        {
            
        }

        private async UniTask WarmUp()
        {
            IWarmUpper levelWarmUpper = await _levelDataProvider.GetLevelWarmUpper();
            await levelWarmUpper.WarmUp();
        }

        private async UniTask DisableLoadingScreen()
        {
            IWindowLogic loadScreen = await _windowUIProvider.GetLoadScreenWindowFromProvider();
            
            await loadScreen.Disable();
        }

        private async UniTask CreateLoadingScreen()
        {
            ILevelObjectFactory levelObjectFactory = await _levelDataProvider.GetLevelObjectFactory();
            await levelObjectFactory.CreateCommonUI();
            await levelObjectFactory.CreateLoadingScreen();
        }
        
        private async UniTask SpawnLevelObjects()
        {
            ILevelObjectFactory levelObjectFactory = await _levelDataProvider.GetLevelObjectFactory();
            
            await levelObjectFactory.CreateCamera();
            await levelObjectFactory.CreateAllObjects();
            await levelObjectFactory.CreateAllUIObjects();
        }
    }
}