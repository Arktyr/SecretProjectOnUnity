using Infrastructure.Gameplay.Persons.AnyCharacter;
using Infrastructure.Gameplay.Persons.AnyCharacter.Abilities;
using Infrastructure.Gameplay.Persons.Common.Abilities;
using Infrastructure.Instatiator;
using Infrastructure.Static_Data.Data;
using UnityEngine;

namespace Infrastructure.Factories.AbilitiesFactory
{
    public class AbilityFactory : IAbilityFactory
    {
        private readonly IInstantiator _instantiator;

        public AbilityFactory(IInstantiator instantiator)
        {
            _instantiator = instantiator;
        }

        public IAbility CreateTeleportAbility(ICharacter character, 
            Transform player,
            SceneData sceneData, 
            PlayerData playerData)
        {
            CharacterTeleport characterTeleport = _instantiator.Instantiate<CharacterTeleport>();

            Teleport teleport = _instantiator.Instantiate<Teleport>();
            
            teleport.Construct(player, sceneData.MapSize);
            
            characterTeleport.Construct(character.CharacterMovement, teleport, 
                playerData.PlayerTeleport.TeleportCooldown, playerData.PlayerTeleport.TeleportDistance);

            return characterTeleport;
        }
    }
}