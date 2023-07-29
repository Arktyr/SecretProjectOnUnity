using System;

namespace Infrastructure.Gameplay.Persons.Common.Injuring
{
    public interface IHealth : IDamageable, IHealing
    {
        public event Action Died;
    }
}