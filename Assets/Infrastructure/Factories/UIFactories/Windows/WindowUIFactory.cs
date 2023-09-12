using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Infrastructure.Addressable.AssetsAddresses.UI;
using Infrastructure.Addressable.Loader;
using Infrastructure.Factories.UIFactories.Buttons;
using Infrastructure.Gameplay.UI.Windows;
using Infrastructure.Gameplay.UI.Windows.LoadScreen;
using Infrastructure.Instatiator;
using Infrastructure.Providers;
using Infrastructure.Providers.Common;
using Infrastructure.Providers.Windows;
using Infrastructure.Static_Data.Configs.UI.Windows;
using UnityEngine;
using UnityEngine.UI;

namespace Infrastructure.Factories.UIFactories.Windows
{
    public class WindowUIFactory : IWindowUIFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly IAddressableLoader _addressableLoader;
        private readonly IButtonUIFactory _buttonUIFactory;
        private readonly ICommonUIProvider _uiProvider;
        private readonly IWindowUIProvider _windowUIProvider;

        private readonly AllUIAssetsAddresses _allUIAssetsAddresses;
        private readonly AllWindowsAnimationsConfig _allWindowsAnimations;

        public WindowUIFactory(IInstantiator instantiator,
            IStaticDataProvider staticDataProvider,
            IAddressableLoader addressableLoader,
            IButtonUIFactory buttonUIFactory,
            ICommonUIProvider uiProvider,
            IWindowUIProvider windowUIProvider)
        {
            _instantiator = instantiator;
            _allUIAssetsAddresses = staticDataProvider.AllAssetsAddresses.AllUIAssetsAddresses;
            _allWindowsAnimations = staticDataProvider.UIData.AllWindowsAnimationsConfig;
            _addressableLoader = addressableLoader;
            _buttonUIFactory = buttonUIFactory;
            _uiProvider = uiProvider;
            _windowUIProvider = windowUIProvider;
        }


        public async UniTask WarmUp()
        {
            _buttonUIFactory.WarmUp();
            
            await _addressableLoader.LoadGameObject(_allUIAssetsAddresses.LoadScreenUIAddresses.LoadScreenWindow);
            await _addressableLoader.LoadGameObject(_allUIAssetsAddresses.MainMenuUIAddresses.MainMenuWindow);
            await _addressableLoader.LoadGameObject(_allUIAssetsAddresses.PauseMenuUIAddresses.PauseWindow);
        }

        public async UniTask<GameObject> Create(WindowType windowType)
        {
            Canvas canvas = await _uiProvider.GetCanvasFromProvider();
            Transform root = canvas.transform.root;
            
            switch (windowType)
            {
                case WindowType.MainMenu:
                    return await CreateMainMenu(root);
                case WindowType.Pause:
                    return await CreatePauseMenu(root);
                case WindowType.Settings:
                    return null;
                case WindowType.LoadScreen:
                    return await CreateLoadScreen(root);
                default:
                    Debug.LogError($"{windowType}, doesn't exist");
                    return null;
            }
        }

        private async UniTask<GameObject> CreateLoadScreen(Transform root)
        {
            GameObject loadScreenWindow =
                await _addressableLoader.LoadGameObject(_allUIAssetsAddresses.LoadScreenUIAddresses.LoadScreenWindow);
            GameObject loadScreenPrefab = _instantiator.InstantiatePrefab(loadScreenWindow, root);
            
            LoadScreenLogic loadScreenLogic = _instantiator.Instantiate<LoadScreenLogic>();
            
            loadScreenLogic.Construct(loadScreenPrefab, _allWindowsAnimations.LoadScreenWindowConfig);
            
            _windowUIProvider.SetLoadScreenWindowToProvider(loadScreenLogic);

            return loadScreenPrefab;
        }

        private async UniTask<GameObject> CreateMainMenu(Transform root)
        {
            GameObject mainMenuWindow =
                await _addressableLoader.LoadGameObject(_allUIAssetsAddresses.MainMenuUIAddresses.MainMenuWindow);

            GameObject prefab = _instantiator.InstantiatePrefab(mainMenuWindow, root);
            
            _buttonUIFactory.Create(ButtonType.PlayButton, root);
            _buttonUIFactory.Create(ButtonType.SettingsButtonMainMenu, root);
            _buttonUIFactory.Create(ButtonType.QuitButton, root);

            prefab.transform.SetSiblingIndex(0);
            
            return prefab;
        }

        private async UniTask<GameObject> CreatePauseMenu(Transform root)
        {
            GameObject pauseMenuWindow =
                await _addressableLoader.LoadGameObject(_allUIAssetsAddresses.PauseMenuUIAddresses.PauseWindow);

            GameObject pauseMenuPrefab = _instantiator.InstantiatePrefab(pauseMenuWindow, root);

            _buttonUIFactory.Create(ButtonType.ResumeButton, pauseMenuPrefab.transform);
            _buttonUIFactory.Create(ButtonType.SettingsButtonPauseMenu, pauseMenuPrefab.transform);
            _buttonUIFactory.Create(ButtonType.ReturnToMainMenuButton, pauseMenuPrefab.transform);

            IWindowLogic windowLogic = CreateWindowLogic(pauseMenuPrefab, _allWindowsAnimations.PauseMenuWindowConfig);
            
            _windowUIProvider.SetPauseMenuWindowToProvider(windowLogic);
            
            pauseMenuPrefab.transform.SetSiblingIndex(0);

            return pauseMenuPrefab;
        }

        private IWindowLogic CreateWindowLogic(GameObject prefab, WindowAnimationConfig windowAnimationConfig)
        {
            PauseWindowLogic pauseWindowLogic = _instantiator.Instantiate<PauseWindowLogic>();
            pauseWindowLogic.Construct(prefab, windowAnimationConfig);
            return pauseWindowLogic;
        }
    }
}