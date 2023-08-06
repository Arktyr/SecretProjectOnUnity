using System.Collections.Generic;
using Infrastructure.Gameplay.Persons.Common.Injuring;

namespace Infrastructure.Gameplay.Persons.AnyCharacter
{
    public interface ICharacterWatcher
    {
        public IReadOnlyList<IDamageNotifier> Characters { get; }

        public void RemoveDeadCharacters();
    }
}