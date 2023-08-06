using UnityEngine;

namespace Infrastructure.Gameplay.Persons.Common.Movement
{
    public class Movement : IMovable
    {
        private Rigidbody _entity;
        
        private float _speed;
        
        public void Construct(Rigidbody entity, float speed)
        {
            if (_speed < 0) Debug.LogError($"{speed}, can't be < 0)");

            _entity = entity;
            _speed = speed;
        }
        
        public void Move(Vector3 direction)
        {
            Vector3 velocity = direction * _speed * Time.fixedDeltaTime;

            _entity.velocity = velocity;
        }
    }
}