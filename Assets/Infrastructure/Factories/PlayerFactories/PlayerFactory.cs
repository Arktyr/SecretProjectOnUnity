using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Infrastructure.Addressable.Loader;
using Infrastructure.Factories.AbilitiesFactory;
using Infrastructure.Factories.CharactersFactory;
using Infrastructure.Gameplay.Persons.AnyCharacter;
using Infrastructure.Gameplay.Persons.AnyCharacter.Abilities;
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
        
        private readonly IPlayerCameraFactory _playerCameraFactory;

        private readonly IPlayerProvider _playerProvider;
        
        public PlayerFactory(IStaticDataProvider staticDataProvider,
            IInstantiator instantiator,
            IAddressableLoader addressableLoader,
            IPlayerCameraFactory playerCameraFactory,
            ICharacterFactory characterFactory,
            IPlayerStateMachineFactory playerStateMachineFactory,
            IPlayerProvider playerProvider)
        {
            _staticDataProvider = staticDataProvider;
            _instantiator = instantiator;
            _addressableLoader = addressableLoader;
            _playerCameraFactory = playerCameraFactory;
            _characterFactory = characterFactory;
            _playerStateMachineFactory = playerStateMachineFactory;
            _playerProvider = playerProvider;
        }
        
        public async UniTask<Player> Create()
        {
            GameObject playerPrefab = await CreatePlayerPrefab();
            
            CharacterAnimator characterAnimator = CreatePlayerAnimator(playerPrefab);
            
            PlayerCamera playerCamera =  await _playerCameraFactory.Create(playerPrefab);
            
            ICharacter character =
                _characterFactory.Create(playerPrefab, _staticDataProvider.PlayerData.CharacterData);
            
            IPlayerStateMachine playerStateMachine = 
                _playerStateMachineFactory.Construct(characterAnimator, character.CharacterMovement);
            
            Player player = _instantiator.Instantiate<Player>();
            
            player.Construct(character, playerStateMachine, playerCamera);
            
            _playerProvider.SetPlayerToProvider(player);
            _playerProvider.SetCharacterLocationToProvider(character.CharacterMovement.CharacterLocation);

            return player;
        }
        
        private async UniTask<GameObject> CreatePlayerPrefab()
        {
            GameObject playerPrefab = await _addressableLoader.LoadGameObject(_staticDataProvider.AllAssetsAddresses
                .AllCharacterAddresses.AllPlayableCharactersAddresses.CommonCharacter);
            
            return _instantiator.InstantiatePrefab(playerPrefab);;
        }

        private CharacterAnimator CreatePlayerAnimator(GameObject playerPrefab)
        {
            Animator animator = playerPrefab.GetComponent<Animator>();

            CharacterAnimator characterAnimator = _instantiator.Instantiate<CharacterAnimator>();
            
            characterAnimator.Construct(animator);

            return characterAnimator;
        }
    }
}