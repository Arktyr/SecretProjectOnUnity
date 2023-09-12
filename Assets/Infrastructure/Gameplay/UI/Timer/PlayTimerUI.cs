using System;
using Infrastructure.Gameplay.Timer;
using UnityEngine.UI;

namespace Infrastructure.Gameplay.UI
{
    public class PlayTimerUI : IPlayTimerUI
    {
        private readonly IPlayTimer _playTimer;

        private Text _timer;

        public PlayTimerUI(IPlayTimer playTimer)
        {
            _playTimer = playTimer;
        }

        public void Construct(Text timer)
        {
            _timer = timer;
        }

        public void Start() => _playTimer.Time.Changed += ChangeTime;

        public void Stop() => _playTimer.Time.Changed -= ChangeTime;
        
        private void ChangeTime(DateTime time) => _timer.text = time.ToLongTimeString();
    }
}