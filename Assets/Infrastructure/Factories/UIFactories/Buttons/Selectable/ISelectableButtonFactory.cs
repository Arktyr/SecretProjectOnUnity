using System;
using Cysharp.Threading.Tasks;
using Infrastructure.Static_Data.Configs.UI.Buttons;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Infrastructure.Factories.UIFactories.Buttons.Selectable
{
    public interface ISelectableButtonFactory
    {
        public UniTask WarmUp();
        
        public UniTask<GameObject> CreateSelectableButton(AssetReferenceGameObject buttonReference,
            Action action,
            SelectableButtonAnimationConfig config,
            Transform root);
    }
}