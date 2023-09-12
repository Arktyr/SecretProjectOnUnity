using System;
using Cysharp.Threading.Tasks;
using Infrastructure.CodeBase.UI.Buttons;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Infrastructure.Factories.UIFactories.Buttons.Base
{
    public interface IBaseButtonUIFactory
    {
        public UniTask WarmUp();
        
        public BaseButton CreateBaseButton(Action action, GameObject buttonPrefab);

        public UniTask<GameObject> CreateButtonPrefab(AssetReferenceGameObject buttonReference, Transform root);
    }
}