using System;

namespace Infrastructure.CodeBase.Services.UnSubscribe
{
    public interface IDisposableService : IDisposable
    {
        public event Action OnDisposable;
    }
}