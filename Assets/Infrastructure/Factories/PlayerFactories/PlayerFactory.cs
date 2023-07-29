using Cysharp.Threading.Tasks;
using Infrastructure.Addressable.Loader;
using Infrastructure.Factories.AbilitiesFactory;
using Infrastructure.Factories.CharactersFactory;
using Infrastructure.Gameplay.Persons.AnyCharacter;
using Infrastructure.Gameplay.Persons.Common.Abilities;
using Infrastructure.Gameplay.Persons.PlayerControlled;
using Infrastructure.Gameplay.Persons.PlayerControlled.CameraControl;
using Infrastructure.Providers;
using UnityEngine;
using IInstantiator = Infrastructure.Instatiator.IInstantiator;
using IPlayerStateMachine = Infrastructure.Gameplay.Persons.PlayerControlled.StateMachine.IPlayerStateMachine;

namespace Infrastructure.Factories.PlayerFactories
{
    public class PlayerFactory : IPlayerFactory
    {
        private readonly IStaticDataProvider _staticDataProvider;
        private readonly IInstantiator _instantiator;
        private readonly IAddressableLoader _addressableLoader;
        
        private readonly IPlayerStateMachineFactory _playerStateMachineFactory;
        private readonly ICharacterFactory _characterFactory;
        private readonly IAbilityFactory _abilityFactory;

        private readonly IPlayerCameraFactory _playerCameraFactory;

        private readonly IPlayerProvider _playerProvider;
        
        public PlayerFactory(IStaticDataProvider staticDataProvider,
            IInstantiator instantiator,
            IAddressableLoader addressableLoader,
            IPlayerCameraFactory playerCameraFactory,
            ICharacterFactory characterFactory,
            IAbilityFactory abilityFactory,
            IPlayerStateMachineFactory playerStateMachineFactory,
            IPlayerProvider playerProvider)
        {
            _staticDataProvider = staticDataProvider;
            _instantiator = instantiator;
            _addressableLoader = addressableLoader;
            _playerCameraFactory = playerCameraFactory;
            _characterFactory = characterFactory;
            _abilityFactory = abilityFactory;
            _playerStateMachineFactory = playerStateMachineFactory;
            _playerProvider = playerProvider;
        }
        
        public async UniTask<Player> Create()
        {
            GameObject playerPrefab = await CreatePlayerPrefab();

            PlayerAnimator playerAnimator = CreatePlayerAnimator(playerPrefab);
            
            PlayerCamera playerCamera =  await _playerCameraFactory.Create(playerPrefab);
            
            ICharacter character = _characterFactory.Create(playerPrefab, _staticDataProvider.PlayerData.CharacterData);

            IAbility characterTeleport = _abilityFactory.CreateTeleportAbility(character, playerPrefab.transform,
                _staticDataProvider.SceneData, _staticDataProvider.PlayerData);
            
            IPlayerStateMachine playerStateMachine = 
                _playerStateMachineFactory.Construct(playerAnimator, character.CharacterMovement);
            
            Player player = _instantiator.Instantiate<Player>();
            
            player.Construct(character, characterTeleport, playerStateMachine, playerCamera);
            
            _playerProvider.SetPlayerToProvider(player);
            _playerProvider.SetPlayerTransformToProvider(playerPrefab.transform);

            return player;
        }
        
        private async UniTask<GameObject> CreatePlayerPrefab()
        {
            GameObject playerPrefab = await _addressableLoader.LoadGameObject(_staticDataProvider.AllAssetsAddresses
                .AllCharacterAddresses.AllPlayableCharactersAddresses.CommonCharacter);
            
            return _instantiator.InstantiatePrefab(playerPrefab);;
        }

        private PlayerAnimator CreatePlayerAnimator(GameObject playerPrefab)
        {
            Animator animator = playerPrefab.GetComponent<Animator>();

            PlayerAnimator playerAnimator = _instantiator.Instantiate<PlayerAnimator>();
            
            playerAnimator.Construct(animator);

            return playerAnimator;
        }
    }
}