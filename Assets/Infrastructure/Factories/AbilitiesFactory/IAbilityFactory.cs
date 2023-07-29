using Infrastructure.Gameplay.Persons.AnyCharacter;
using Infrastructure.Gameplay.Persons.Common.Abilities;
using Infrastructure.Static_Data.Data;
using UnityEngine;

namespace Infrastructure.Factories.AbilitiesFactory
{
    public interface IAbilityFactory
    {
        IAbility CreateTeleportAbility(ICharacter character, Transform player, 
            SceneData sceneData, PlayerData playerData);
    }
}