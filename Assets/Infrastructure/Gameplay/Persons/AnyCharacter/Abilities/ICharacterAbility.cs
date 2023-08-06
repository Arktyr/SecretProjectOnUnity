using Infrastructure.Gameplay.Persons.AnyCharacter.Abilities;
using Infrastructure.Gameplay.Persons.Common.Abilities;

namespace Infrastructure.Gameplay.Persons.AnyCharacter
{
    public interface ICharacterAbility
    {
        public void TryUseAllAbilitiesByType(AbilityType abilityType);

        public void TryUseAllAbilities();

        public void TryUseSingleAbility<T>() where T : IAbility;
    }
}