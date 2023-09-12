using System;
using Infrastructure.CodeBase.Observables;

namespace Infrastructure.Gameplay.Timer
{
    public interface IPlayTimer
    {
        public void Reset();
        public void Stop();
        public void Start();
        float TotalTimeInSeconds { get;}
        public IReadOnlyObservable<DateTime> Time { get; }
    }
}