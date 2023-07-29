using System;

namespace Infrastructure.CodeBase.General
{
    public interface IReadOnlyObservable<out T>
    {
        event Action<T> Changed;
        
        T Value { get; }
    }
}