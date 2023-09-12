using Infrastructure.Gameplay.Persons.Common.Injuring;
using UnityEngine;

namespace Infrastructure.Gameplay.Persons.AnyCharacter
{
    public class CharacterInjuring : ICharacterInjuring
    {
        public IDamageNotifier DamageNotifier { get; private set; }
        
        public IHealth Health { get; private set; }

        public void Construct(IHealth health,
            IDamageNotifier damageNotifier)
        {
            Health = health;
            DamageNotifier = damageNotifier;

           SubscribeToEvents();
        }
        
        private void TakeDamage(float damage) => Health.TakeDamage(damage);
        
        public void SubscribeToEvents()
        {
            DamageNotifier.ReceivedDamage += TakeDamage;
            Health.Died += Dispose;
        }

        private void UnSubscribeFromEvents()
        {
            DamageNotifier.ReceivedDamage -= TakeDamage;
            Health.Died -= Dispose;
        }
        
        public void Dispose() => UnSubscribeFromEvents();
    }
}