using System;
using Infrastructure.Gameplay.Persons.Common.Injuring;
using UnityEngine;

namespace MonoBehaviours.Characters.Notifiers
{
    public class HealNotifier : MonoBehaviour, IHealNotifier
    {
        public event Action<float> ReceivedHealing;
        
        public void Heal(float value)
        {
            if (value < 0) Debug.LogError($"{value}: heal can't be < 0");
            
            ReceivedHealing?.Invoke(value);
        }
    }
}