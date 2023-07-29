using Infrastructure.Gameplay.Persons.Common.Movement;
using UnityEngine;

namespace Infrastructure.Gameplay.Persons.AnyCharacter
{
    public class CharacterMovement : ICharacterMovement
    {
        private IMovable _movement;
        private IRotatable _rotatable;

        private CharacterController _characterController;
        
        public Vector2 Direction { get; private set; }
        
        public void Construct(CharacterController characterController,
            IMovable characterMovement,
            IRotatable characterRotatable)
        {
            _characterController = characterController;
            _movement = characterMovement;
            _rotatable = characterRotatable;
        }

        public void Move(Vector2 direction)
        {
            Direction = direction;
            _movement.Move(direction);
        }
        
        public void Rotate(Vector2 direction) => _rotatable.Rotate(direction);

        public void DisableCharacterController() => _characterController.enabled = false;
        
        public void EnableCharacterController() => _characterController.enabled = true;
    }
}