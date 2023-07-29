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

        public PlayerCameraFactory(IInstantiator instantiator, 
            IStaticDataProvider staticDataProvider,
            IAddressableLoader addressableLoader)
        {
            _instantiator = instantiator;
            _staticDataProvider = staticDataProvider;
            _addressableLoader = addressableLoader;
        }


        public async UniTask<PlayerCamera> Create(GameObject playerPrefab)
        {
            GameObject prefabCamera = await CreatePrefabCamera();

            CinemachineVirtualCamera cinemachineCamera =
                CreateFollowForCinemachineVirtualCamera(prefabCamera, playerPrefab);
            
            PlayerCameraZoom playerCameraZoom = CreatePlayerCameraController(cinemachineCamera);

            PlayerCameraMove playerCameraMove = CreatePlayerCameraMove(cinemachineCamera);
            
            PlayerCamera playerCamera = CreatePlayerCamera(playerCameraZoom, playerCameraMove, cinemachineCamera);

            return playerCamera;
        }

        private PlayerCameraMove CreatePlayerCameraMove(CinemachineVirtualCamera cinemachineVirtualCamera)
        {
            PlayerCameraMove playerCameraMove = _instantiator.Instantiate<PlayerCameraMove>();
            playerCameraMove.Construct(cinemachineVirtualCamera);

            return playerCameraMove;
        }

        private async UniTask<GameObject> CreatePrefabCamera()
        {
            GameObject prefabCamera = await _addressableLoader.LoadGameObject(_staticDataProvider.AllAssetsAddresses
                .PlayerAssetsAddresses.CameraAssetsAddresses.Camera);
            
            return _instantiator.InstantiatePrefab(prefabCamera);
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