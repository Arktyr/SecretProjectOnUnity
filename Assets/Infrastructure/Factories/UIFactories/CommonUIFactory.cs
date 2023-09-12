using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Infrastructure.Addressable.AssetsAddresses.UI;
using Infrastructure.Addressable.Loader;
using Infrastructure.Instatiator;
using Infrastructure.Providers;
using Infrastructure.Providers.Common;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Infrastructure.Factories.UIFactories
{
    public class CommonUIFactory : ICommonUIFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly CommonUIAddresses _commonUIAddresses;
        private readonly IAddressableLoader _addressableLoader;
        private readonly ICommonUIProvider _uiProvider;
        private readonly IStaticDataProvider _staticDataProvider;

        public CommonUIFactory(IInstantiator instantiator,
            IStaticDataProvider staticDataProvider,
            IAddressableLoader addressableLoader,
            ICommonUIProvider uiProvider)
        {
            _instantiator = instantiator;
            _commonUIAddresses = staticDataProvider.AllAssetsAddresses.AllUIAssetsAddresses.CommonUIAddresses;
            _staticDataProvider = staticDataProvider;
            _addressableLoader = addressableLoader;
            _uiProvider = uiProvider;
        }

        public async UniTask WarmUp()
        {
            await _addressableLoader.LoadGameObject(_commonUIAddresses.CanvasPrefab);
            await _addressableLoader.LoadGameObject(_commonUIAddresses.EventSystemPrefab);
        }

        public async UniTask Create()
        {
            Canvas canvas = await CreateCanvas();
            _uiProvider.SetCanvasToProvider(canvas);

            EventSystem eventSystem = await CreateEventSystem();
            _uiProvider.SetEventSystemToProvider(eventSystem);

            GameObject uiRoot = await CreateUIRoot(canvas);
            _uiProvider.SetUIRootToProvider(uiRoot);
        }

        private async UniTask<GameObject> CreateUIRoot(Canvas canvas)
        {
            GameObject emptyObject =
                await _addressableLoader.LoadGameObject(_staticDataProvider.AllAssetsAddresses.EmptyObject);

            return _instantiator.InstantiatePrefab(emptyObject, canvas.transform.root);
        }

        private async UniTask<Canvas> CreateCanvas()
        {
            Canvas canvasPrefab = await _addressableLoader.LoadComponent<Canvas>
                (_commonUIAddresses.CanvasPrefab);
            
            return _instantiator.InstantiatePrefabForComponent(canvasPrefab);
        }

        private async UniTask<EventSystem> CreateEventSystem()
        {
            EventSystem eventSystemPrefab =
                await _addressableLoader.LoadComponent<EventSystem>(_commonUIAddresses.EventSystemPrefab);

            return _instantiator.InstantiatePrefabForComponent(eventSystemPrefab);
        }
    }
}