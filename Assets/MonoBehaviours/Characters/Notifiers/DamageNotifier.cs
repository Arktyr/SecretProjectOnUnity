﻿using System;
using Infrastructure.Gameplay.Persons.Common.Injuring;
using UnityEngine;

namespace MonoBehaviours.Characters.Notifiers
{
    public class DamageNotifier : MonoBehaviour, IDamageNotifier
    {
        public event Action<float> ReceivedDamage;
        
        public CharacterType CharacterType { get; private set; }

        public void SetCharacterType(CharacterType characterType) => CharacterType = characterType;

        public void TakeDamage(float damage)
        {
            if (damage < 0) Debug.LogError($"{damage}: damage can't be < 0");
            
            ReceivedDamage?.Invoke(damage);
        }
    }
}