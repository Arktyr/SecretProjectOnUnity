using Infrastructure.CodeBase.Services.UnSubscribe;
using UnityEngine;

namespace Infrastructure.Gameplay.Persons.AnyCharacter
{
    public interface ICharacter
    {
        public ICharacterMovement CharacterMovement { get; } 
            
        public ICharacterInjuring CharacterInjuring { get; }
        
        public ICharacterRecovering CharacterRecovering { get; }
        
        public ICharacterAbility CharacterAbility { get;}
        
        public GameObject CharacterPrefab { get; }
        
        public IDisposableService DisposableService { get; }
    }
}