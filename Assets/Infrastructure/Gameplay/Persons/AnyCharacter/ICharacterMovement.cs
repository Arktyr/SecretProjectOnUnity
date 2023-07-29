using Infrastructure.Gameplay.Persons.Common.Movement;
using UnityEngine;

namespace Infrastructure.Gameplay.Persons.AnyCharacter
{
    public interface ICharacterMovement : IMovable, IRotatable
    {
        Vector2 Direction { get; }
        
        void DisableCharacterController();
        
        void EnableCharacterController();
        
    }
}