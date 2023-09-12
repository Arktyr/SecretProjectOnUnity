using System;
using Infrastructure.CodeBase.Observables;

namespace Infrastructure.Gameplay.Persons.Common.Injuring
{
    public interface IHealth : IDamageable, IHealing
    {
        public event Action Died;

        public IReadOnlyObservable<float> Healths { get; }
    }
}