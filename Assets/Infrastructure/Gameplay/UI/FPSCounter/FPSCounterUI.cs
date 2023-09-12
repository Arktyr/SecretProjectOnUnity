using System;
using Cysharp.Threading.Tasks;
using Infrastructure.CodeBase.Services.UnSubscribe;
using Infrastructure.CodeBase.Services.Update;
using TMPro;
using UnityEngine;

namespace Infrastructure.Gameplay.UI.FPSCounter
{
    public class FPSCounterUI : IFPSCounterUI
    {
        private TMP_Text _counter;
        
        private readonly IDisposableService _disposableService;
        private readonly IUpdaterService _updaterService;

        private bool _isCanRefresh;

        public FPSCounterUI(IDisposableService disposableService,
            IUpdaterService updaterService)
        {
            _disposableService = disposableService;
            _updaterService = updaterService;
        }

        public void Construct(TMP_Text counter)
        {
            _counter = counter;

            SubscribeToEvents();
        }

        private void UnSubscribeEvents()
        {
            _updaterService.Update -= GetFPS;
            _disposableService.OnDisposable -= Dispose;
        }

        private void SubscribeToEvents()
        {
            _updaterService.Update += GetFPS;
            _disposableService.OnDisposable += Dispose;
        }

        private void GetFPS(float deltaTime)
        {
            float currentFPS = MathF.Round(1f / deltaTime);
            
            _counter.SetText($"{currentFPS}");
        }

        public void Dispose() => UnSubscribeEvents();
    }
}