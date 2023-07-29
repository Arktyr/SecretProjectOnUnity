using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Infrastructure.Providers
{
    public class UIProvider : IUIProvider
    {
        private Canvas _canvas;
        private EventSystem _eventSystem;
        private FixedJoystick _fixedJoystick;
        
        
        public async UniTask<Canvas> GetCanvasFromProvider()
        {
            await UniTask.WaitUntil(() => _canvas != null);
            
            return _canvas;
        }

        public async UniTask<EventSystem> GetEventSystemFromProvider()
        {
            await UniTask.WaitUntil(() => _eventSystem != null);
            
            return _eventSystem;
        }

        public async UniTask<FixedJoystick> GetFixedJoystickFromProvider()
        {
            await UniTask.WaitUntil(() => _fixedJoystick != null);
            
            return _fixedJoystick;
        }

        public void SetCanvasToProvider(Canvas canvas) => _canvas = canvas;
        
        public void SetEventSystemToProvider(EventSystem eventSystem) => _eventSystem = eventSystem;

        public void SetFixedJoystickToProvider(FixedJoystick fixedJoystick) => _fixedJoystick = fixedJoystick;
    }
}