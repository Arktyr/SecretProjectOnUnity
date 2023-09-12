using Cysharp.Threading.Tasks;
using Infrastructure.Addressable.Loader;
using Infrastructure.Instatiator;
using Infrastructure.Providers;
using UnityEngine;

namespace Infrastructure.Factories.Camera
{
    public class CameraFactory : ICameraFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly IAddressableLoader _addressableLoader;
        private readonly IStaticDataProvider _staticDataProvider;
        private readonly ILevelDataProvider _levelDataProvider;

        public CameraFactory(IInstantiator instantiator,
            IAddressableLoader addressableLoader,
            IStaticDataProvider staticDataProvider,
            ILevelDataProvider levelDataProvider)
        {
            _instantiator = instantiator;
            _addressableLoader = addressableLoader;
            _staticDataProvider = staticDataProvider;
            _levelDataProvider = levelDataProvider;
        }

        public async UniTask WarmUp()
        {
            await _addressableLoader.LoadGameObject(_staticDataProvider.AllAssetsAddresses
                .PlayerAssetsAddresses.CameraAssetsAddresses.Camera);
        }

        public async UniTask<GameObject> CreatePrefabCamera()
        {
            GameObject camera = await _addressableLoader.LoadGameObject(_staticDataProvider.AllAssetsAddresses
                .PlayerAssetsAddresses.CameraAssetsAddresses.Camera);
            
            GameObject prefabCamera = _instantiator.InstantiatePrefab(camera);
            
            _levelDataProvider.SetCamera(prefabCamera);

            return prefabCamera;
        }
    }
}