using System;
using Infrastructure.Gameplay.Persons.Common.Injuring;

namespace Infrastructure.Gameplay.Persons.AnyCharacter
{
    public interface ICharacterInjuring : IDisposable
    {
        public IDamageNotifier DamageNotifier { get; }
        
        public IHealth Health { get; }

        public void SubscribeToEvents();
    }
}