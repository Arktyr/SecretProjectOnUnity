using System.Collections.Generic;
using Infrastructure.Gameplay.Persons.Common.Abilities;
using UnityEngine;

namespace Infrastructure.Gameplay.Persons.AnyCharacter.Abilities
{
    public class CharacterAbility : ICharacterAbility
    {
        private Dictionary<AbilityType, IAbility> _abilities = new ();
        
        public void SetAbilities(Dictionary <AbilityType, IAbility> abilities) => _abilities = abilities;
        
        private bool IsHaveAnyAbility()
        {
            if (_abilities.Count > 0) return true;
            
            return false;
        }
        
        private IAbility IsHaveThisAbility<T>() where T: IAbility
        {
            foreach (var ability in _abilities)
            {
                if (ability.Key == AbilityType.Passive) return null;
                if (ability.Value is T) return ability.Value;
            }
            return null;
        }

        public void TryUseAllAbilitiesByType(AbilityType abilityType)
        {
            if (IsHaveAnyAbility() == false) return;

            foreach (var ability in _abilities)
            {
                if (ability.Key == abilityType) ability.Value.Use();
            }
        }
        
        public void TryUseAllAbilities()
        {
            if (IsHaveAnyAbility() == false) return;

            foreach (var ability in _abilities)
            {
                if (ability.Key == AbilityType.Passive) return;
                ability.Value.Use();
            }
        }
        
        public void TryUseSingleAbility<T>() where T: IAbility
        {
            if (IsHaveAnyAbility() == false) return;
            
            IAbility ability = IsHaveThisAbility<T>();

            if (ability == null) Debug.Log($"{nameof(T)} Ability has not found");

            IsHaveThisAbility<T>().Use();
        }
    }
}