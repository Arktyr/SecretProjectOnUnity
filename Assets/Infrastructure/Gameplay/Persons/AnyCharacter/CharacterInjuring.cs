using Infrastructure.Gameplay.Persons.Common.Injuring;

namespace Infrastructure.Gameplay.Persons.AnyCharacter
{
    public class CharacterInjuring : ICharacterInjuring
    {
        public ICharacterNotifier CharacterNotifier { get; private set; }
        public IHealth Health { get; private set; }
        
        public void Construct(IHealth health,
            ICharacterNotifier characterNotifier)
        {
            Health = health;
            CharacterNotifier = characterNotifier;

           SubscribeToEvents();
        }
        
        private void TakeDamage(float damage) => Health.TakeDamage(damage);

        private void Heal(float value) => Health.Heal(value); 

        private void SubscribeToEvents()
        {
            CharacterNotifier.ReceivedDamage += TakeDamage;
            CharacterNotifier.ReceivedHealing += Heal;
            Health.Died += Dispose;
        }

        private void UnSubscribeFromEvents()
        {
            CharacterNotifier.ReceivedHealing -= Heal;
            CharacterNotifier.ReceivedDamage -= TakeDamage;
            Health.Died -= Dispose;
        }
        
        public void Dispose()
        {
            UnSubscribeFromEvents();
        }
    }
}