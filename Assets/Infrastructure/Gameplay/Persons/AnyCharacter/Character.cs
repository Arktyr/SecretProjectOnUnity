using System;
using Infrastructure.Gameplay.Persons.Common.Injuring;
using UnityEngine;

namespace Infrastructure.Gameplay.Persons.AnyCharacter
{
    public class Character : ICharacter
    {
        public GameObject CharacterPrefab { get; private set; }
        
        public ICharacterMovement CharacterMovement { get; private set; }
        public ICharacterInjuring CharacterInjuring { get; private set; }
        public ICharacterRecovering CharacterRecovering { get; private set; }
      
        public CharacterAnimator CharacterAnimator { get; private set; }
        public ICharacterAbility CharacterAbility { get; private set; }
        
        public void Construct(ICharacterMovement characterMovement, 
            ICharacterInjuring characterInjuring,
            ICharacterRecovering characterRecovering,
            ICharacterAbility characterAbility,
            GameObject characterPrefab)
        {
            CharacterMovement = characterMovement;
            CharacterInjuring = characterInjuring;
            CharacterRecovering = characterRecovering;
            CharacterAbility = characterAbility;
            CharacterPrefab = characterPrefab;
        }
    }
}