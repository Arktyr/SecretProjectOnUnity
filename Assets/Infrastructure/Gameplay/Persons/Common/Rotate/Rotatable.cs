using UnityEngine;

namespace Infrastructure.Gameplay.Persons.Common.Movement
{
    public class Rotatable : IRotatable
    {
        private Transform _playerTransform;

        private float _rotateTime;
        
        public void Construct(Transform playerTransform, float rotateTime)
        {
            if (rotateTime < 0) Debug.LogError($"{rotateTime}, can't be < 0");
            
            _playerTransform = playerTransform;
            _rotateTime = rotateTime;
        }

        public void Rotate(Vector3 direction)
        {
            if (direction.magnitude != 0)
            {
                _playerTransform.rotation = Quaternion.Lerp(_playerTransform.rotation,
                    Quaternion.LookRotation(direction), _rotateTime * Time.fixedDeltaTime);
            }
        }
    }
}