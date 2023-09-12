using System;
using Infrastructure.CodeBase.Observables;
using UnityEngine;

namespace Infrastructure.Gameplay.Persons.Common.Injuring
{
    public class Health : IHealth
    {
        private float _maxHealth;
        private const float MinHealth = 0;
        
        private readonly Observable<float> _health = new();
        public IReadOnlyObservable<float> Healths => _health;
        
        public event Action Died;
        
        public void Construct(float health, float maxHealth)
        {
            _health.Value = health;
            _maxHealth = maxHealth;
        }

        public void TakeDamage(float damage)
        {
            if (damage < 0) Debug.LogError($"{damage}: damage can't be < 0");

            _health.Value = Mathf.Clamp(_health.Value - damage, MinHealth, float.MaxValue);
            TryDie();
        }

        private void TryDie()
        {
            if (_health.Value == 0 ) Died?.Invoke();
        }

        public void Heal(float value)
        {
            if (value < 0) Debug.LogError($"{value}: heal can't be < 0");
            
            _health.Value = Mathf.Clamp(_health.Value + value, MinHealth, _maxHealth);
        }
    }
}