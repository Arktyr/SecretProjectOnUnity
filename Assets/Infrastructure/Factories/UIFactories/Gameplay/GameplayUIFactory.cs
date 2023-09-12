using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Infrastructure.Addressable.AssetsAddresses.UI;
using Infrastructure.Addressable.Loader;
using Infrastructure.Factories.UIFactories.Buttons;
using Infrastructure.Factories.UIFactories.Windows;
using Infrastructure.Gameplay.Persons.Common.Injuring;
using Infrastructure.Gameplay.Persons.PlayerControlled;
using Infrastructure.Gameplay.UI;
using Infrastructure.Gameplay.UI.Bars;
using Infrastructure.Gameplay.UI.FPSCounter;
using Infrastructure.Instatiator;
using Infrastructure.Providers;
using Infrastructure.Providers.Common;
using Infrastructure.Providers.Windows;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Infrastructure.Factories.UIFactories.Gameplay
{
    public class GameplayUIFactory : IGameplayUIFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly AllUIAssetsAddresses _allUIAssetsAddresses;
        private readonly IAddressableLoader _addressableLoader;
        private readonly ICommonUIProvider _commonUIProvider;
        private readonly IUIProvider _uiProvider;
        private readonly IPlayerProvider _playerProvider;
        private readonly IButtonUIFactory _buttonUIFactory;
        private readonly IWindowUIFactory _windowUIFactory;
        

        public GameplayUIFactory(IInstantiator instantiator,
            IStaticDataProvider staticDataProvider,
            IAddressableLoader addressableLoader,
            ICommonUIProvider commonUIProvider,
            IUIProvider uiProvider,
            IPlayerProvider playerProvider,
            IButtonUIFactory buttonUIFactory,
            IWindowUIFactory windowUIFactory)
        {
            _instantiator = instantiator;
            _allUIAssetsAddresses = staticDataProvider.AllAssetsAddresses.AllUIAssetsAddresses;
            _addressableLoader = addressableLoader;
            _commonUIProvider = commonUIProvider;
            _uiProvider = uiProvider;
            _playerProvider = playerProvider;
            _buttonUIFactory = buttonUIFactory;
            _windowUIFactory = windowUIFactory;
        }

        public async UniTask Create()
        {
            Canvas canvas = await _commonUIProvider.GetCanvasFromProvider();
            Transform root = canvas.transform.root;
            
            FixedJoystick fixedJoystick = await CreateFixedJoystick(root);
            _uiProvider.SetFixedJoystickToProvider(fixedJoystick);

            PlayTimerUI playTimerUI = await CreateTimer(root);
            _uiProvider.SetPlayTimerUIToProvider(playTimerUI);
            
            await CreateFPSCounter(root);
            await CreateHealthBar(root);
            await _buttonUIFactory.Create(ButtonType.PauseButton, root);
            await _windowUIFactory.Create(WindowType.Pause);
        }

        private async UniTask CreateFPSCounter(Transform root)
        {
            GameObject fpsCounterUIAsset = 
                await _addressableLoader.LoadGameObject(_allUIAssetsAddresses.GameplayUIAddresses.FPSCounter);

            GameObject fpsCounterUIPrefab = _instantiator.InstantiatePrefab(fpsCounterUIAsset, root);
            
            fpsCounterUIPrefab.transform.SetSiblingIndex(0);

            FPSCounterUI fpsCounterUI =
                _instantiator.Instantiate<FPSCounterUI>();
            
            fpsCounterUI.Construct(fpsCounterUIPrefab.GetComponent<TMP_Text>());
        }

        private async UniTask<HealthBar> CreateHealthBar(Transform root)
        {
            GameObject healthBarPrefab =
                await _addressableLoader.LoadGameObject(_allUIAssetsAddresses.GameplayUIAddresses.HealthBar);

            GameObject healthBar = _instantiator.InstantiatePrefab(healthBarPrefab, root);
            
            Image[] fieldPart = healthBar.GetComponentsInChildren<Image>();

            TMP_Text text = healthBar.GetComponentInChildren<TMP_Text>();

            HealthBar healthBarUI = _instantiator.Instantiate<HealthBar>();

            IHealth health = await GetHealth();
            
            healthBar.transform.SetSiblingIndex(0);
            
            healthBarUI.Construct(health, fieldPart, text, health.Healths.Value);

            return healthBarUI;
        }

        private async UniTask<IHealth> GetHealth()
        {
            Player player = await _playerProvider.GetPlayerFromProvider();
            
            return player.Character.CharacterInjuring.Health;
        }

        private async UniTask<PlayTimerUI> CreateTimer(Transform root)
        {
            Text text = await _addressableLoader.LoadComponent<Text>(
                _allUIAssetsAddresses.GameplayUIAddresses.PlayTimer);

            Text timer = _instantiator.InstantiatePrefabForComponent(text, root);

            PlayTimerUI playTimerUI = _instantiator.Instantiate<PlayTimerUI>();
            
            playTimerUI.Construct(timer);
            
            timer.transform.SetSiblingIndex(0);

            return playTimerUI;
        }

        private async UniTask<FixedJoystick> CreateFixedJoystick(Transform root)
        {
            FixedJoystick fixedJoystickPrefab =
                await _addressableLoader.LoadComponent<FixedJoystick>(_allUIAssetsAddresses.InputAssetsAddresses
                    .JoyStick);
            
            FixedJoystick fixedJoystick = _instantiator.InstantiatePrefabForComponent(fixedJoystickPrefab, root);
            
            fixedJoystick.transform.SetSiblingIndex(0);

            return fixedJoystick;
        }
    }
}