using System;
using UnityEngine;

namespace Infrastructure.CodeBase.Services.UnSubscribe
{
    public class DisposableService : IDisposableService
    {
        public event Action OnDisposable;

        public void Dispose()
        {
            OnDisposable?.Invoke();
        } 
    }
}