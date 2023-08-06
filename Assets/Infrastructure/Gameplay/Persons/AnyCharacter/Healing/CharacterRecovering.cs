using Infrastructure.Gameplay.Persons.Common.Injuring;

namespace Infrastructure.Gameplay.Persons.AnyCharacter
{
    public class CharacterRecovering : ICharacterRecovering
    {
        public IHealNotifier HealNotifier { get; private set; }

        public IHealth Health { get; private set; }
        
        public void Construct(IHealth health,
            IHealNotifier healNotifier)
        {
            Health = health;
            HealNotifier = healNotifier;

            SubscribeToEvents();
        }
        
        private void Heal(float value) => Health.Heal(value); 

        private void SubscribeToEvents()
        {
            HealNotifier.ReceivedHealing += Heal;
            Health.Died += Dispose;
        }

        private void UnSubscribeFromEvents()
        {
            HealNotifier.ReceivedHealing -= Heal;
            Health.Died -= Dispose;
        }
        
        public void Dispose()
        {
            UnSubscribeFromEvents();
        }
    }
}