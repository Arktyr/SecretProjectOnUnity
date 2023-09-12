using System;

namespace Infrastructure.Gameplay.Persons.Common.Injuring
{
    public interface IDamageNotifier : IDamageable
    {
        public event Action<float> ReceivedDamage;

        public CharacterType CharacterType { get; }
    }
}