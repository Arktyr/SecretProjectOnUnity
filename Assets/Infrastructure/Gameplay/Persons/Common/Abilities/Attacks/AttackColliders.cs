using System.Collections.Generic;
using Infrastructure.CodeBase.Services.Overlap;
using Infrastructure.Gameplay.Persons.Common.Abilities;
using Infrastructure.Gameplay.Persons.Common.Injuring;

namespace Infrastructure.Gameplay.Persons.AnyCharacter.Abilities
{
    public class AttackColliders : IAttackColliders
    {
        private IAttack _attack;
        
        private CharacterLocation _characterLocation;
        private CharacterType _characterType;

        private readonly IOverlapService _overlapService;

        public AttackColliders(IOverlapService overlapService)
        {
            _overlapService = overlapService;
        }

        public void Construct(IAttack attack,
            CharacterLocation characterLocation,
            CharacterType characterType)
        {
            _attack = attack;
            
            _characterLocation = characterLocation;
            _characterType = characterType;
        }

        public void Hit(int damage)
        {
            List<DamageNotifier> characters =
                _overlapService.OverlapForComponent<DamageNotifier>(
                    _overlapService.SphereOverlap(_characterLocation.CurrentPosition(), 2));

            foreach (var character in characters)
            {
                if (character.CharacterType != _characterType) _attack.Hit(damage, character);
            }
        }
    }
}