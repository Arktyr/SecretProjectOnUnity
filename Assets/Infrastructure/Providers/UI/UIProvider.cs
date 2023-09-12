using Cysharp.Threading.Tasks;
using Infrastructure.Gameplay.Timer;
using Infrastructure.Gameplay.UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Infrastructure.Providers
{
    public class UIProvider : IUIProvider
    {
        private FixedJoystick _fixedJoystick;
        private IPlayTimerUI _playTimer;

        public async UniTask<FixedJoystick> GetFixedJoystickFromProvider()
        {
            await UniTask.WaitUntil(() => _fixedJoystick != null);
            
            return _fixedJoystick;
        }
        
        public async UniTask<IPlayTimerUI> GetPlayTimerUIFromProvider()
        {
            await UniTask.WaitUntil(() => _playTimer != null);
            
            return _playTimer;
        }
        
        public void SetFixedJoystickToProvider(FixedJoystick fixedJoystick) => _fixedJoystick = fixedJoystick;

        public void SetPlayTimerUIToProvider(IPlayTimerUI playTimer) => _playTimer = playTimer;
    }
}