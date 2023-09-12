using System;
using Cysharp.Threading.Tasks;
using Infrastructure.CodeBase.UI.Buttons;
using Infrastructure.Factories.UIFactories.Buttons.Base;
using Infrastructure.Gameplay.UI.Animations.ButtonAnimation;
using Infrastructure.Gameplay.UI.Animations.ButtonAnimation.ButtonAnimation;
using Infrastructure.Instatiator;
using Infrastructure.Static_Data.Configs.UI.Buttons;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Infrastructure.Factories.UIFactories.Buttons.Selectable
{
    public class SelectableButtonUIFactory : ISelectableButtonFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly IBaseButtonUIFactory _baseButtonUIFactory;

        public SelectableButtonUIFactory(IInstantiator instantiator,
            IBaseButtonUIFactory baseButtonUIFactory)
        {
            _instantiator = instantiator;
            _baseButtonUIFactory = baseButtonUIFactory;
        }

        public async UniTask WarmUp()
        {
            await _baseButtonUIFactory.WarmUp();
        }

        public async UniTask<GameObject> CreateSelectableButton(AssetReferenceGameObject buttonReference,
            Action action,
            SelectableButtonAnimationConfig config,
            Transform root)
        {
            GameObject buttonPrefab = await _baseButtonUIFactory.CreateButtonPrefab(buttonReference, root);

            BaseButton baseButton = _baseButtonUIFactory.CreateBaseButton(action, buttonPrefab);

            ISelectableButtonAnimation selectableButtonAnimation =
                CreateSelectableButtonAnimation(buttonPrefab, config);

            SelectableButton selectableButton = _instantiator.Instantiate<SelectableButton>();
            selectableButton.Construct(baseButton, selectableButtonAnimation);

            return buttonPrefab;
        }
        
        private ISelectableButtonAnimation CreateSelectableButtonAnimation(GameObject buttonPrefab, 
            SelectableButtonAnimationConfig config)
        {
            SelectableButtonAnimation selectableButtonAnimation =
                _instantiator.Instantiate<SelectableButtonAnimation>();
            
            selectableButtonAnimation.Construct(buttonPrefab, config);

            return selectableButtonAnimation;
        }
    }
}