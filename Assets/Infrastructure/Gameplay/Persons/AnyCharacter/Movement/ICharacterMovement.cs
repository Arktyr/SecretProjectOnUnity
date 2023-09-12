using Infrastructure.Gameplay.Persons.AnyCharacter.Movement;
using Infrastructure.Gameplay.Persons.Common.Movement;
using UnityEngine;

namespace Infrastructure.Gameplay.Persons.AnyCharacter
{
    public interface ICharacterMovement : IMovable, IRotatable
    { 
        CharacterLocation CharacterLocation { get; }
    }
}