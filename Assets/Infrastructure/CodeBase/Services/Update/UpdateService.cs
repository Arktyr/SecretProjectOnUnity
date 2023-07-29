using System;
using UnityEngine;
using Zenject;

namespace Infrastructure.CodeBase.Services.Update
{
    public class UpdateService: IUpdaterService, ITickable, IFixedTickable, ILateTickable
    {
        private bool _isTicking;

        public event Action<float> Update; 
        public event Action<float> FixedUpdate; 
        public event Action<float> LateUpdate; 

        public void StartTicking() => _isTicking = true;

        public void StopTicking() => _isTicking = false;
        
        public void Tick()
        {
            if (_isTicking) Update?.Invoke(Time.deltaTime);
        }

        public void FixedTick()
        {
            if (_isTicking) FixedUpdate?.Invoke(Time.fixedDeltaTime);
        }

        public void LateTick()
        {
            if (_isTicking) LateUpdate?.Invoke(Time.deltaTime);
        }
    }
}