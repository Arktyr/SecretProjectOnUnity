using System;
using UnityEngine;

namespace Infrastructure.Gameplay.Persons.Common.Injuring
{
    public class CharacterNotifier : ICharacterNotifier
    {
        public event Action<float> ReceivedDamage;
        public event Action<float> ReceivedHealing;

        public void TakeDamage(float damage)
        {
            if (damage < 0) Debug.LogError($"{damage}: damage can't be < 0");
            
            ReceivedDamage?.Invoke(damage);
        }

        public void Heal(float value)
        {
            if (value < 0) Debug.LogError($"{value}: heal can't be < 0");
            
            ReceivedHealing?.Invoke(value);
        }
    }
}