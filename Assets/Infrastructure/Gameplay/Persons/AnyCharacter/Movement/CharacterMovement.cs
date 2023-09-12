using Infrastructure.Gameplay.Persons.AnyCharacter.Movement;
using Infrastructure.Gameplay.Persons.Common.Movement;
using UnityEngine;

namespace Infrastructure.Gameplay.Persons.AnyCharacter
{
    public class CharacterMovement : ICharacterMovement
    {
        private IMovable _movement;
        private IRotatable _rotatable;

        public CharacterLocation CharacterLocation { get; private set; }
        
        public void Construct(IMovable characterMovement,
            IRotatable characterRotatable,
            CharacterLocation characterLocation)
        {
            _movement = characterMovement;
            _rotatable = characterRotatable;
            CharacterLocation = characterLocation;
        }

        public void Move(Vector3 direction) => _movement.Move(direction);

        public void Rotate(Vector3 direction) => _rotatable.Rotate(direction);
    }
}