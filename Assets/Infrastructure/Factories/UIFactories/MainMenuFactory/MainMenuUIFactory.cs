using System;
using Cysharp.Threading.Tasks;
using Infrastructure.Factories.Camera;
using Infrastructure.Factories.UIFactories;
using Infrastructure.Factories.UIFactories.Windows;
using Infrastructure.Gameplay.UI.Windows.LoadScreen;
using Infrastructure.Providers;
using Infrastructure.Providers.MainMenu;
using Infrastructure.Providers.Windows;
using UnityEngine;

namespace Infrastructure.Factories
{
    public class MainMenuUIFactory : IMainMenuUIFactory
    {
        private readonly IMainMenuDataProvider _mainMenuDataProvider;
        private readonly IWindowUIFactory _windowUIFactory;
        private readonly ICommonUIFactory _commonUIFactory;
        private readonly ICameraFactory _cameraFactory;
        private readonly IWindowUIProvider _windowUIProvider;

        public MainMenuUIFactory(IMainMenuDataProvider mainMenuDataProvider,
            IWindowUIFactory windowUIFactory,
            ICommonUIFactory commonUIFactory,
            ICameraFactory cameraFactory,
            IWindowUIProvider windowUIProvider)
        {
            _mainMenuDataProvider = mainMenuDataProvider;
            _windowUIFactory = windowUIFactory;
            _commonUIFactory = commonUIFactory;
            _cameraFactory = cameraFactory;
            _windowUIProvider = windowUIProvider;
        }

        public void Initialize() => SetSelfToProvider();

        private void SetSelfToProvider() => _mainMenuDataProvider.SetMainMenuUIFactory(this);

        public async UniTask CreateMainMenu()
        {
            await _commonUIFactory.Create();

            await _windowUIFactory.Create(WindowType.MainMenu);

            await CreateLoadScreenWindows();

            await _cameraFactory.CreatePrefabCamera();
        }

        private async UniTask CreateLoadScreenWindows()
        {
           GameObject prefab = await _windowUIFactory.Create(WindowType.LoadScreen);
           prefab.transform.SetSiblingIndex(Int32.MaxValue);
        }
    }
}