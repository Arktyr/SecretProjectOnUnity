using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Infrastructure.Addressable.AssetsAddresses.UI;
using Infrastructure.CodeBase.UI.Buttons;
using Infrastructure.Factories.UIFactories.Buttons.Selectable;
using Infrastructure.Gameplay.UI.Buttons.Logic;
using Infrastructure.Instatiator;
using Infrastructure.Providers;
using UnityEngine;

namespace Infrastructure.Factories.UIFactories.Buttons
{
    public class ButtonUIFactory : IButtonUIFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly ISelectableButtonFactory _selectableButtonFactory;

        private readonly AllUIAssetsAddresses _allUIAssetsAddresses;
        private readonly AllButtonsAnimationsConfig _allButtonsAnimationsConfig;

        public ButtonUIFactory(IInstantiator instantiator,
            ISelectableButtonFactory selectableButtonFactory,
            IStaticDataProvider staticDataProvider)
        {
            _instantiator = instantiator;
            _selectableButtonFactory = selectableButtonFactory;

            _allUIAssetsAddresses = staticDataProvider.AllAssetsAddresses.AllUIAssetsAddresses;
            _allButtonsAnimationsConfig = staticDataProvider.UIData.AllButtonsAnimationsConfig;
        }

        public async UniTask WarmUp()
        {
            await _selectableButtonFactory.WarmUp();
        }

        public async UniTask<GameObject> Create(ButtonType buttonType, Transform root)
        {
            switch (buttonType)
            {
                case ButtonType.PlayButton:
                    return await CreatePlayButton(root);
                case ButtonType.SettingsButtonMainMenu:
                    return await CreateSettingsButtonMainMenu(root);
                case ButtonType.QuitButton:
                    return await CreateQuitButton(root);
                case ButtonType.PauseButton:
                    return await CreatePauseButton(root);
                case ButtonType.ResumeButton:
                    return await CreateResumeButton(root);
                case ButtonType.ReturnToMainMenuButton:
                    return await CreateReturnToMainMenuButton(root);
                case ButtonType.SettingsButtonPauseMenu:
                    return await CreateSettingsButtonPauseMenu(root);
                default:
                    Debug.LogError($"{buttonType}, doesnt exist");
                    return null;
           
            }
        }

        private async UniTask<GameObject> CreateSettingsButtonPauseMenu(Transform root)
        {
            SettingsButtonLogic buttonLogic = _instantiator.Instantiate<SettingsButtonLogic>();
            
            return await _selectableButtonFactory.CreateSelectableButton(
                _allUIAssetsAddresses.PauseMenuUIAddresses.SettingsButton,
                buttonLogic.OpenSettings,
                _allButtonsAnimationsConfig.PauseMenuButtonsAnimationConfig.SettingButton,
                root);
        }

        private async UniTask<GameObject> CreatePlayButton(Transform root)
        {
            PlayButtonLogic buttonLogic = _instantiator.Instantiate<PlayButtonLogic>();
            
            return await _selectableButtonFactory.CreateSelectableButton(
                _allUIAssetsAddresses.MainMenuUIAddresses.PlayButton,
                buttonLogic.Play,
                _allButtonsAnimationsConfig.MainMenuButtonsAnimationConfig.PlayButton,
                root);
        }  
        
        private async UniTask<GameObject> CreateSettingsButtonMainMenu(Transform root)
        {
            SettingsButtonLogic buttonLogic = _instantiator.Instantiate<SettingsButtonLogic>();
            
            return await _selectableButtonFactory.CreateSelectableButton(
                _allUIAssetsAddresses.MainMenuUIAddresses.SettingsButton,
                buttonLogic.OpenSettings,
                _allButtonsAnimationsConfig.MainMenuButtonsAnimationConfig.SettingButton,
                root);
        } 
        
        private async UniTask<GameObject> CreateQuitButton(Transform root)
        {
            QuitButtonLogic buttonLogic = _instantiator.Instantiate<QuitButtonLogic>();
            
            return await _selectableButtonFactory.CreateSelectableButton(
                _allUIAssetsAddresses.MainMenuUIAddresses.QuitButton,
                buttonLogic.Quit,
                _allButtonsAnimationsConfig.MainMenuButtonsAnimationConfig.ExitButton,
                root);
        }
        
        private async UniTask<GameObject> CreatePauseButton(Transform root)
        {
            PauseButtonLogic buttonLogic = _instantiator.Instantiate<PauseButtonLogic>();

            GameObject prefab = await _selectableButtonFactory.CreateSelectableButton(
                _allUIAssetsAddresses.PauseMenuUIAddresses.PauseButton,
                buttonLogic.Pause,
                _allButtonsAnimationsConfig.PauseMenuButtonsAnimationConfig.PauseButton,
                root);

            prefab.transform.SetSiblingIndex(0);
            
            return prefab;
        }

        private async UniTask<GameObject> CreateResumeButton(Transform root)
        {
            ResumeButtonLogic buttonLogic = _instantiator.Instantiate<ResumeButtonLogic>();
            
            return await _selectableButtonFactory.CreateSelectableButton(
                _allUIAssetsAddresses.PauseMenuUIAddresses.ResumeButton,
                buttonLogic.Resume,
                _allButtonsAnimationsConfig.PauseMenuButtonsAnimationConfig.ResumeButton,
                root);
        }

        private async UniTask<GameObject> CreateReturnToMainMenuButton(Transform root)
        {
            ReturnToMainMenuButtonLogic buttonLogic = _instantiator.Instantiate<ReturnToMainMenuButtonLogic>();
            
            return await _selectableButtonFactory.CreateSelectableButton(
                _allUIAssetsAddresses.PauseMenuUIAddresses.ReturnToMainMenuButton,
                buttonLogic.Return,
                _allButtonsAnimationsConfig.PauseMenuButtonsAnimationConfig.ReturnToMainMenuButton,
                root);
        }
    }
}