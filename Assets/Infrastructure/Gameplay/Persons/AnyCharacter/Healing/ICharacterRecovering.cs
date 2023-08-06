using Infrastructure.Gameplay.Persons.Common.Injuring;

namespace Infrastructure.Gameplay.Persons.AnyCharacter
{
    public interface ICharacterRecovering
    {
        public IHealNotifier HealNotifier { get; }
        
        public IHealth Health { get; }
    }
}