using Infrastructure.Gameplay.Persons.AnyCharacter;
using Infrastructure.Gameplay.Persons.Common.Injuring;
using Infrastructure.Gameplay.Persons.Common.Movement;
using Infrastructure.Instatiator;
using Infrastructure.Static_Data.Data;
using UnityEngine;

namespace Infrastructure.Factories.CharactersFactory
{
    public class CharacterFactory : ICharacterFactory
    {
        private IInstantiator _instantiator;

        private CharacterController _characterController;
        private CharacterData _characterData;
        
        public CharacterFactory(IInstantiator instantiator)
        {
            _instantiator = instantiator;
        }
        
        public ICharacter Create(GameObject characterPrefab, CharacterData characterData)
        {
            SetCreateParams(characterPrefab, characterData);
            
            ICharacterMovement characterMovement = CreateCharacterMovement();

            ICharacterInjuring characterInjuring = CreateCharacterInjuring();

            ICharacter character = CreateCharacter(characterMovement, characterInjuring);

            return character;
        }

        private ICharacterMovement CreateCharacterMovement()
        {
            CharacterMovement characterMovement = _instantiator.Instantiate<CharacterMovement>();

            HorizontalMovement horizontalMovement = _instantiator.Instantiate<HorizontalMovement>();

            HorizontalRotatable horizontalRotatable = _instantiator.Instantiate<HorizontalRotatable>();
            
            horizontalMovement.Construct(_characterController, _characterData.CharacterMovementConfig.Speed);
           
            horizontalRotatable.Construct(_characterController.transform, 
                _characterData.CharacterMovementConfig.RotateTime);
            
            characterMovement.Construct(_characterController, horizontalMovement, horizontalRotatable );

            return characterMovement;
        }
        
        private ICharacterInjuring CreateCharacterInjuring()
        {
            CharacterInjuring characterInjuring = _instantiator.Instantiate<CharacterInjuring>();

            Health health = _instantiator.Instantiate<Health>();
            
            CharacterNotifier characterNotifier = _instantiator.Instantiate<CharacterNotifier>();
            
            health.Construct(_characterData.CharacterStats.Health, _characterData.CharacterStats.MaxHealth);

            characterInjuring.Construct(health, characterNotifier);

            return characterInjuring;
        }
        
        private ICharacter CreateCharacter(ICharacterMovement characterMovement,
            ICharacterInjuring characterInjuring)
        {
            Character character = _instantiator.Instantiate<Character>();

            character.Construct(characterMovement, characterInjuring);

            return character;
        }

        private void SetCreateParams(GameObject characterPrefab, CharacterData characterData)
        {
            _characterController = characterPrefab.GetComponent<CharacterController>();
            _characterData = characterData;
        }
    }
}