using System;
using Infrastructure.Gameplay.Persons.Common.Injuring;

namespace Infrastructure.Gameplay.Persons.AnyCharacter
{
    public interface ICharacterInjuring : IDisposable
    {
        public ICharacterNotifier CharacterNotifier { get; }
        
        public IHealth Health { get; }
    }
}