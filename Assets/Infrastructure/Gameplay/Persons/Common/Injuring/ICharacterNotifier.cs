using System;

namespace Infrastructure.Gameplay.Persons.Common.Injuring
{
    public interface ICharacterNotifier : IDamageable, IHealing
    {
        public event Action<float> ReceivedDamage;

        public event Action<float> ReceivedHealing;
    }
}