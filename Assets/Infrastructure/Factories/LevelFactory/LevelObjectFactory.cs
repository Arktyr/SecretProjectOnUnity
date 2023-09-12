using Cysharp.Threading.Tasks;
using DG.Tweening;
using Infrastructure.Factories.Camera;
using Infrastructure.Factories.PlayerFactories;
using Infrastructure.Factories.UIFactories;
using Infrastructure.Factories.UIFactories.Gameplay;
using Infrastructure.Factories.UIFactories.Windows;
using Infrastructure.Providers;
using UnityEngine;
using UnityEngine.UI;

namespace Infrastructure.Creation
{
    public class LevelObjectFactory : ILevelObjectFactory
    {
        private readonly IPlayerFactory _playerFactory;
        private readonly ICommonUIFactory _commonUIFactory;
        private readonly IGameplayUIFactory _gameplayUIFactory;
        private readonly ILevelDataProvider _levelDataProvider;
        private readonly IWindowUIFactory _windowUIFactory;
        private readonly ICameraFactory _cameraFactory;

        public LevelObjectFactory(IPlayerFactory playerFactory,
            ILevelDataProvider levelDataProvider,
            ICommonUIFactory commonUIFactory,
            IGameplayUIFactory gameplayUIFactory,
            IWindowUIFactory windowUIFactory,
            ICameraFactory cameraFactory)
        {
            _playerFactory = playerFactory;
            _levelDataProvider = levelDataProvider;
            _commonUIFactory = commonUIFactory;
            _gameplayUIFactory = gameplayUIFactory;
            _windowUIFactory = windowUIFactory;
            _cameraFactory = cameraFactory;
        }

        public void Initialize() => SetSelfToProvider();
        
        public async UniTask CreateAllObjects() => await _playerFactory.Create();

        public async UniTask CreateCommonUI() => await _commonUIFactory.Create();

        public async UniTask CreateCamera() => await _cameraFactory.CreatePrefabCamera();

        public async UniTask CreateLoadingScreen()
        {
           await _windowUIFactory.Create(WindowType.LoadScreen);
        } 

        public async UniTask CreateAllUIObjects() => await _gameplayUIFactory.Create();

        private void SetSelfToProvider() => _levelDataProvider.SetLevelObjectFactory(this);
    }
}