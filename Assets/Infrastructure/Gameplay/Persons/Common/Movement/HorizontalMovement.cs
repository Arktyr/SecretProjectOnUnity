using UnityEngine;

namespace Infrastructure.Gameplay.Persons.Common.Movement
{
    public class HorizontalMovement : IMovable
    {
        private CharacterController _characterController;
        
        private float _speed;

        public void Construct(CharacterController characterController, float speed)
        {
            if (_speed < 0) Debug.LogError($"{speed}, can't be < 0)");
            
            _characterController = characterController;
            _speed = speed;
        }
        
        public void Move(Vector2 direction)
        {
            Vector3 velocity = new Vector3(direction.x, 0, direction.y) * _speed * Time.fixedDeltaTime;
            
            _characterController.Move(velocity);
        }
    }
}