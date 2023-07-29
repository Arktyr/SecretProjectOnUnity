using UnityEngine;

namespace Infrastructure.Gameplay.Persons.Common.Movement
{
    public class HorizontalRotatable : IRotatable
    {
        private Transform _playerTransform;

        private float _rotateTime;
        
        public void Construct(Transform playerTransform, float rotateTime)
        {
            if (rotateTime < 0) Debug.LogError($"{rotateTime}, can't be < 0");
            
            _playerTransform = playerTransform;
            _rotateTime = rotateTime;
        }

        public void Rotate(Vector2 direction)
        {
            if (direction.magnitude != 0)
            {
                Vector3 currentDirection = new Vector3(direction.x, 0, direction.y);
                
                _playerTransform.rotation = Quaternion.Lerp(_playerTransform.rotation,
                    Quaternion.LookRotation(currentDirection), _rotateTime * Time.fixedDeltaTime);
            }
        }
    }
}