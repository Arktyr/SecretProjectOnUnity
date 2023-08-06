using System;
using System.Collections.Generic;
using Infrastructure.Gameplay.Persons.AnyCharacter;
using Infrastructure.Gameplay.Persons.AnyCharacter.Abilities;
using Infrastructure.Gameplay.Persons.Common.Abilities;
using Infrastructure.Gameplay.Persons.Common.Injuring;
using Infrastructure.Instatiator;
using Infrastructure.Providers;
using Infrastructure.Static_Data.Configs.Player;
using Infrastructure.Static_Data.Data;
using UnityEngine;

namespace Infrastructure.Factories.AbilitiesFactory
{
    public class AbilityFactory : IAbilityFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly IStaticDataProvider _staticDataProvider;

        public AbilityFactory(IInstantiator instantiator,
            IStaticDataProvider staticDataProvider)
        {
            _instantiator = instantiator;
            _staticDataProvider = staticDataProvider;
        }

        public Dictionary<AbilityType, IAbility> CreateAbilities(ICharacter character, 
            GameObject prefab, CharacterData characterData)
        {
            Dictionary<AbilityType, IAbility> abilities = new();

            if (characterData.Abilities == null || characterData.Abilities.Length == 0) return abilities;
            
            foreach (var abilityName in characterData.Abilities)
            {
                switch (abilityName)
                {
                    case AbilityName.CharacterTeleportForward:
                    {
                        IAbility ability =
                            CreateTeleportAbility(character, prefab.transform, characterData.CharacterTeleportConfig ,
                                out AbilityType abilityType);
                        
                        abilities.Add(abilityType, ability);
                        break;
                    }
                    case AbilityName.CharacterAOEAttack:
                    {
                        IAbility ability = 
                            CreateColliderAttack(character, characterData.CharacterType);
                        
                        abilities.Add(AbilityType.Attack, ability);
                        break;
                    }
                        
                    default:
                        throw new ArgumentOutOfRangeException(nameof(abilityName), abilityName, null);
                }
            }

            return abilities;
        }
        
        private IAbility CreateTeleportAbility(ICharacter character, 
            Transform player,
            CharacterTeleportConfig characterTeleportConfig,
            out AbilityType abilityType)
        {
            CharacterTeleportForward characterTeleportForward = _instantiator.Instantiate<CharacterTeleportForward>();

            Teleport teleport = _instantiator.Instantiate<Teleport>();
            
            teleport.Construct(player, _staticDataProvider.LevelData.MapSize);

            Cooldown cooldown = _instantiator.Instantiate<Cooldown>();
            
            cooldown.Construct(characterTeleportConfig.TeleportCooldown);
            
            characterTeleportForward.Construct(character.CharacterMovement, teleport, 
                cooldown, characterTeleportConfig.TeleportDistance);

            abilityType = AbilityType.Movement;

            return characterTeleportForward;
        }

        private IAbility CreateColliderAttack(ICharacter character, CharacterType characterType)
        {
            Attack attack = _instantiator.Instantiate<Attack>();

            AttackColliders attackColliders = _instantiator.Instantiate<AttackColliders>();
            
            attackColliders.Construct(attack ,character.CharacterMovement.CharacterLocation, characterType);
            
            Cooldown cooldown = _instantiator.Instantiate<Cooldown>();
            
            cooldown.Construct(0);

            CharacterAOEAttack characterAoeAttack = _instantiator.Instantiate<CharacterAOEAttack>();
            
            characterAoeAttack.Construct(5, cooldown, attackColliders);
            
            return characterAoeAttack;
        }
    }
}