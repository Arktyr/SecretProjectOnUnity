using System;

namespace Infrastructure.Gameplay.Persons.Common.Injuring
{
    public interface IHealNotifier
    {
        public event Action<float> ReceivedHealing;
    }
}