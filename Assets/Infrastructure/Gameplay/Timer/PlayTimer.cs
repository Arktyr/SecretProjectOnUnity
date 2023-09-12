using System;
using Infrastructure.CodeBase.Observables;
using Infrastructure.CodeBase.Services.Update;

namespace Infrastructure.Gameplay.Timer
{
    public class PlayTimer: IPlayTimer
    {
        private readonly IUpdaterService _updaterService;

        private readonly Observable<DateTime> _time = new();
        
        public PlayTimer(IUpdaterService updateService)
        {
            _updaterService = updateService;
        }

        public float TotalTimeInSeconds { get; private set; }
        
        public IReadOnlyObservable<DateTime> Time => _time;
        
        public void Reset() => _time.Value = DateTime.MinValue;

        public void Start() => _updaterService.Update += Count;
        
        public void Stop() => _updaterService.Update -= Count;

        private void Count(float time)
        {
            _time.Value = _time.Value.AddSeconds(time);
            
            TotalTimeInSeconds = _time.Value.Second + _time.Value.Minute * 60 + _time.Value.Hour * 60 * 60;
        } 
    }
}