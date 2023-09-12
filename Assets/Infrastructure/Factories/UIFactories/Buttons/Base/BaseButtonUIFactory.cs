using System;
using Cysharp.Threading.Tasks;
using Infrastructure.Addressable.AssetsAddresses.UI;
using Infrastructure.Addressable.Loader;
using Infrastructure.CodeBase.UI;
using Infrastructure.CodeBase.UI.Buttons;
using Infrastructure.Instatiator;
using Infrastructure.Providers;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Infrastructure.Factories.UIFactories.Buttons.Base
{
    public class BaseButtonUIFactory : IBaseButtonUIFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly IAddressableLoader _addressableLoader;
        private readonly AllUIAssetsAddresses _allUIAssetsAddresses;

        public BaseButtonUIFactory(IInstantiator instantiator,
            IAddressableLoader addressableLoader,
            IStaticDataProvider staticDataProvider)
        {
            _instantiator = instantiator;
            _addressableLoader = addressableLoader;
            _allUIAssetsAddresses = staticDataProvider.AllAssetsAddresses.AllUIAssetsAddresses;
        }

        public async UniTask WarmUp()
        {
            await _addressableLoader.LoadGameObject(_allUIAssetsAddresses.MainMenuUIAddresses.PlayButton);
            await _addressableLoader.LoadGameObject(_allUIAssetsAddresses.MainMenuUIAddresses.QuitButton);
            await _addressableLoader.LoadGameObject(_allUIAssetsAddresses.MainMenuUIAddresses.SettingsButton);
            
            await _addressableLoader.LoadGameObject(_allUIAssetsAddresses.PauseMenuUIAddresses.PauseButton);
            await _addressableLoader.LoadGameObject(_allUIAssetsAddresses.PauseMenuUIAddresses.ResumeButton);
            await _addressableLoader.LoadGameObject(_allUIAssetsAddresses.PauseMenuUIAddresses.ReturnToMainMenuButton);
            await _addressableLoader.LoadGameObject(_allUIAssetsAddresses.PauseMenuUIAddresses.SettingsButton);
        }

        public BaseButton CreateBaseButton(Action action, GameObject buttonPrefab)
        {
            ControlEvents controlEvents = buttonPrefab.GetComponentInChildren<ControlEvents>();
            
            BaseButton baseButton = _instantiator.Instantiate<BaseButton>();
            
            baseButton.Construct(controlEvents, action);

            return baseButton;
        }
        
        public async UniTask<GameObject> CreateButtonPrefab(AssetReferenceGameObject buttonReference, Transform root)
        {
            GameObject button = await _addressableLoader.LoadGameObject(buttonReference);

            return _instantiator.InstantiatePrefab(button, root);
        }
    }
}