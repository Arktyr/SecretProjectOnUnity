using Cysharp.Threading.Tasks;
using Infrastructure.Factories.Camera;
using Infrastructure.Factories.PlayerFactories;
using Infrastructure.Factories.UIFactories;
using Infrastructure.Factories.UIFactories.Windows;
using Infrastructure.Providers;
using UnityEngine;

namespace Infrastructure.Addressable.WarmUp.Level
{
    public class LevelWarmUpper : IWarmUpper
    {
        private readonly IPlayerFactory _playerFactory;
        private readonly ICommonUIFactory _commonUIFactory;
        private readonly ILevelDataProvider _levelDataProvider;
        private readonly IWindowUIFactory _windowUIFactory;
        private readonly ICameraFactory _cameraFactory;

        public LevelWarmUpper(IPlayerFactory playerFactory,
            ICommonUIFactory commonUIFactory,
            ILevelDataProvider levelDataProvider, 
            IWindowUIFactory windowUIFactory,
            ICameraFactory cameraFactory)
        {
            _playerFactory = playerFactory;
            _commonUIFactory = commonUIFactory;
            _levelDataProvider = levelDataProvider;
            _windowUIFactory = windowUIFactory;
            _cameraFactory = cameraFactory;
        }

        public void Initialize() => _levelDataProvider.SetLevelWarmUpper(this);

        public async UniTask WarmUp()
        {
            await _commonUIFactory.WarmUp();
            await _windowUIFactory.WarmUp();
            await _cameraFactory.WarmUp();
            await _playerFactory.WarmUp();
        }
    }
}