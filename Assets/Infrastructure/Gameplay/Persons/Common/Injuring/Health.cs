using System;
using UnityEngine;

namespace Infrastructure.Gameplay.Persons.Common.Injuring
{
    public class Health : IHealth
    {
        private float _health;
        private float _maxHealth;
        
        public event Action Died;
        
        private const float MinHealth = 0;

        public void Construct(float health, float maxHealth)
        {
            _health = health;
            _maxHealth = maxHealth;
        }

        public void TakeDamage(float damage)
        {
            if (damage < 0) Debug.LogError($"{damage}: damage can't be < 0");

            _health = Mathf.Clamp(_health - damage, MinHealth, float.MaxValue);
            TryDie();
        }

        private void TryDie()
        {
            if (_health == 0 ) Died?.Invoke();
        }

        public void Heal(float value)
        {
            if (value < 0) Debug.LogError($"{value}: heal can't be < 0");
            
            _health = Mathf.Clamp(_health + value, MinHealth, _maxHealth);
        }
    }
}