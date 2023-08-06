using UnityEngine;

namespace Infrastructure.Gameplay.Persons.AnyCharacter
{
    public struct CharacterLocation
    {
        private Transform _transform;
        
        public Vector3 Direction() => _transform.forward;
        public Vector3 CurrentPosition() => _transform.position;
        
        public void Construct(Transform transform)
        {
            _transform = transform;
        }
    }
}