using Cinemachine;
using Cysharp.Threading.Tasks;
using Infrastructure.Addressable.Loader;
using Infrastructure.Gameplay.Persons.PlayerControlled.CameraControl;
using Infrastructure.Instatiator;
using Infrastructure.Providers;
using UnityEngine;

namespace Infrastructure.Factories.PlayerFactories
{
    public class PlayerCameraFactory : IPlayerCameraFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly IStaticDataProvider _staticDataProvider;
        private readonly IAddressableLoader _addressableLoader;
        private readonly ILevelDataProvider _levelDataProvider;

        public PlayerCameraFactory(IInstantiator instantiator, 
            IStaticDataProvider staticDataProvider,
            IAddressableLoader addressableLoader,
            ILevelDataProvider levelDataProvider)
        {
            _instantiator = instantiator;
            _staticDataProvider = staticDataProvider;
            _addressableLoader = addressableLoader;
            _levelDataProvider = levelDataProvider;
        }


        public async UniTask WarmUp()
        {
            await _addressableLoader.LoadGameObject(_staticDataProvider.AllAssetsAddresses.EmptyObject);
        }

        public async UniTask<PlayerCamera> Create(GameObject playerPrefab)
        {
            GameObject prefabCamera = await _levelDataProvider.GetCamera();

            CinemachineVirtualCamera cinemachineCamera =
                CreateFollowForCinemachineVirtualCamera(prefabCamera, playerPrefab);
            
            PlayerCameraZoom playerCameraZoom = CreatePlayerCameraController(cinemachineCamera);

            PlayerCameraMove playerCameraMove = await CreatePlayerCameraMove(cinemachineCamera);
            
            PlayerCamera playerCamera = CreatePlayerCamera(playerCameraZoom, playerCameraMove, cinemachineCamera);

            return playerCamera;
        }

        private async UniTask<PlayerCameraMove>CreatePlayerCameraMove(CinemachineVirtualCamera cinemachineVirtualCamera)
        {
            PlayerCameraMove playerCameraMove = _instantiator.Instantiate<PlayerCameraMove>();
            
            GameObject emptyObject = await CreateEmptyObject();
            
            playerCameraMove.Construct(cinemachineVirtualCamera, emptyObject);

            return playerCameraMove;
        }

        private async UniTask<GameObject> CreateEmptyObject()
        {
            GameObject emptyObjectPrefab = await
                _addressableLoader.LoadGameObject(_staticDataProvider.AllAssetsAddresses.EmptyObject);

            return _instantiator.InstantiatePrefab(emptyObjectPrefab);
        }
        
        private CinemachineVirtualCamera CreateFollowForCinemachineVirtualCamera
            (GameObject prefabCamera, GameObject playerPrefab)
        {
            CinemachineVirtualCamera cinemachineCamera =
                prefabCamera.GetComponentInChildren<CinemachineVirtualCamera>();

            cinemachineCamera.Follow = playerPrefab.transform;

            return cinemachineCamera;
        }

        private PlayerCameraZoom CreatePlayerCameraController(
            CinemachineVirtualCamera cinemachineVirtualCamera)
        {
            PlayerCameraZoom playerCameraZoom = _instantiator.Instantiate<PlayerCameraZoom>();
            playerCameraZoom.Construct(cinemachineVirtualCamera);

            return playerCameraZoom;
        }

        private PlayerCamera CreatePlayerCamera(PlayerCameraZoom playerCameraZoom
        ,PlayerCameraMove playerCameraMove
        ,CinemachineVirtualCamera cinemachineVirtualCamera)
        {
            PlayerCamera playerCamera = _instantiator.Instantiate<PlayerCamera>();
            
            playerCamera.Construct(playerCameraZoom, playerCameraMove, cinemachineVirtualCamera);

            return playerCamera;
        }
    }
}