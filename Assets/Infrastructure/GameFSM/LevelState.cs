using Cysharp.Threading.Tasks;
using DG.Tweening;
using Infrastructure.Addressable.Loader;
using Infrastructure.CodeBase.General.StateMachine.Interfaces;
using Infrastructure.CodeBase.Services.InputService.Base;
using Infrastructure.CodeBase.Services.Update;
using Infrastructure.Gameplay.Spawner;
using Infrastructure.Gameplay.Timer;
using Infrastructure.Gameplay.UI;
using Infrastructure.Providers;
using Infrastructure.Providers.Spawner;
using UnityEngine;

namespace Infrastructure.GameFSM
{
    public class LevelState : IState
    {
        private readonly IPlayTimer _playTimer;
        private readonly IUIProvider _uiProvider;
        private readonly IUpdaterService _updaterService;
        private readonly IInputService _inputService;
        private readonly IEnemySpawnerProvider _enemySpawnerProvider;

        public LevelState(IPlayTimer playTimer,
            IUIProvider uiProvider,
            IUpdaterService updaterService,
            IInputService inputService,
            IEnemySpawnerProvider enemySpawnerProvider)
        {
            _playTimer = playTimer;
            _uiProvider = uiProvider;
            _updaterService = updaterService;
            _inputService = inputService;
            _enemySpawnerProvider = enemySpawnerProvider;
        }

        public async void Exit()
        {
            DOTween.KillAll();
            
            await StopTimer();
            
            _inputService.InputDisable();
        }

        public async void Enter()
        {
            await StartTimer();

            await StartSpawnEnemies();
            
            _updaterService.StartTicking();
            
            _inputService.InputEnable();
        }

        private async UniTask StartSpawnEnemies()
        {
            IEnemySpawner enemySpawner = await _enemySpawnerProvider.GetEnemySpawnerFromProvider();
            
            enemySpawner.StartSpawnEnemies();
        }
        
        private async UniTask StopTimer()
        {
            IPlayTimerUI playTimerUI =  await _uiProvider.GetPlayTimerUIFromProvider();
            playTimerUI.Stop();
            
            _playTimer.Reset();
            _playTimer.Stop();
        }

        private async UniTask StartTimer()
        {
            IPlayTimerUI playTimerUI =  await _uiProvider.GetPlayTimerUIFromProvider();
            playTimerUI.Start();
            
            _playTimer.Reset();
            _playTimer.Start();
        }
    }
}