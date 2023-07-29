using System;

namespace Infrastructure.CodeBase.Services.Update
{
    public interface IUpdaterService
    {
        public event Action<float> Update; 
        public event Action<float> FixedUpdate; 
        public event Action<float> LateUpdate;

        public void StartTicking();

        public void StopTicking();
    }
}