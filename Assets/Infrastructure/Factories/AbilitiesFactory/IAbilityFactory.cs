using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Infrastructure.Gameplay.Persons.AnyCharacter;
using Infrastructure.Gameplay.Persons.AnyCharacter.Abilities;
using Infrastructure.Gameplay.Persons.Common.Abilities;
using Infrastructure.Static_Data.Data;
using UnityEngine;

namespace Infrastructure.Factories.AbilitiesFactory
{
    public interface IAbilityFactory
    {
        Dictionary<AbilityType, IAbility> CreateAbilities(ICharacter character, 
            GameObject prefab, CharacterData characterData);
    }
}