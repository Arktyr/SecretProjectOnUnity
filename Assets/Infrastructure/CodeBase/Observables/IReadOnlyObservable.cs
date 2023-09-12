using System;

namespace Infrastructure.CodeBase.Observables
{
    public interface IReadOnlyObservable<out T>
    {
        event Action<T> Changed;
        T Value { get; }    
    }
}