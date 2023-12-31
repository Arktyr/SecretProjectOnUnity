﻿using Infrastructure.CodeBase.Services.UnSubscribe;
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
        
        public IDisposableService DisposableService { get; private set; }

        public Character(IDisposableService disposableService)
        {
            DisposableService = disposableService;
        }

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