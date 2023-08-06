using Infrastructure.Factories.AbilitiesFactory;
using Infrastructure.Gameplay.Persons.AnyCharacter;
using Infrastructure.Gameplay.Persons.AnyCharacter.Abilities;
using Infrastructure.Gameplay.Persons.Common.Injuring;
using Infrastructure.Gameplay.Persons.Common.Movement;
using Infrastructure.Instatiator;
using Infrastructure.Static_Data.Data;
using UnityEngine;

namespace Infrastructure.Factories.CharactersFactory
{
    public class CharacterFactory : ICharacterFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly IAbilityFactory _abilityFactory;

        private GameObject _prefab;
        private Rigidbody _entity;
        private CharacterData _characterData;
        public CharacterFactory(IInstantiator instantiator,
            IAbilityFactory abilityFactory)
        {
            _instantiator = instantiator;
            _abilityFactory = abilityFactory;
        }
        
        public ICharacter Create(GameObject characterPrefab, CharacterData characterData)
        {
            SetCreateParams(characterPrefab, characterData);
            
            ICharacterMovement characterMovement = CreateCharacterMovement();

            IHealth health = CreateHealth();

            ICharacterInjuring characterInjuring = CreateCharacterInjuring(health, characterData.CharacterType);

            ICharacterRecovering characterRecovering = CreateCharacterRecovering(health);
            
            CharacterAbility characterAbility = CreateCharacterAbility();
            
            ICharacter character = CreateCharacter(characterMovement, characterInjuring, characterRecovering, characterAbility);

            characterAbility.SetAbilities(_abilityFactory.CreateAbilities(character, characterPrefab, characterData));

            return character;
        }

        private CharacterAbility CreateCharacterAbility()
        {
            CharacterAbility characterAbility = _instantiator.Instantiate<CharacterAbility>();

            return characterAbility;
        }
        
        private IHealth CreateHealth()
        {
            Health health = _instantiator.Instantiate<Health>();
            
            health.Construct(_characterData.CharacterStats.Health, _characterData.CharacterStats.MaxHealth);

            return health;
        }

        private ICharacterRecovering CreateCharacterRecovering(IHealth health)
        {
            CharacterRecovering characterRecovering = _instantiator.Instantiate<CharacterRecovering>();

            IHealNotifier healNotifier = _prefab.GetComponent<IHealNotifier>();
            
            characterRecovering.Construct(health, healNotifier);

            return characterRecovering;
        }

        private ICharacterMovement CreateCharacterMovement()
        {
            CharacterMovement characterMovement = _instantiator.Instantiate<CharacterMovement>();

            Movement movement = _instantiator.Instantiate<Movement>();

            Rotatable rotatable = _instantiator.Instantiate<Rotatable>();
            
            CharacterLocation characterLocation = CreateCharacterLocation(_prefab.transform);
            
            movement.Construct(_entity, _characterData.CharacterMovementConfig.Speed);
           
            rotatable.Construct(_entity.transform, 
                _characterData.CharacterMovementConfig.RotateTime);
            
            characterMovement.Construct(movement, rotatable, characterLocation);

            return characterMovement;
        }
        
        private ICharacterInjuring CreateCharacterInjuring(IHealth health, CharacterType characterType)
        {
            CharacterInjuring characterInjuring = _instantiator.Instantiate<CharacterInjuring>();

            DamageNotifier damageNotifier = _prefab.GetComponent<DamageNotifier>();
            
            damageNotifier.SetCharacterType(characterType);
            
            characterInjuring.Construct(health, damageNotifier);

            return characterInjuring;
        }

        private CharacterLocation CreateCharacterLocation(Transform transform)
        {
            CharacterLocation characterLocation = _instantiator.Instantiate<CharacterLocation>();
            
            characterLocation.Construct(transform);
            
            return characterLocation;
        }
        
        private ICharacter CreateCharacter(ICharacterMovement characterMovement,
            ICharacterInjuring characterInjuring, ICharacterRecovering characterRecovering,
            ICharacterAbility characterAbility)
        {
            Character character = _instantiator.Instantiate<Character>();
            
            character.Construct(characterMovement, characterInjuring, characterRecovering, characterAbility, _prefab);

            return character;
        }

        private void SetCreateParams(GameObject characterPrefab, CharacterData characterData)
        {
            _prefab = characterPrefab;
            _entity = characterPrefab.GetComponent<Rigidbody>();
            _characterData = characterData;
        }
    }
}