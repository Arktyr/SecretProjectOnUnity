using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Infrastructure.Providers
{
    public interface IUIProvider
    {
        UniTask<Canvas> GetCanvasFromProvider();
        
        UniTask<EventSystem> GetEventSystemFromProvider();
        
        UniTask<FixedJoystick> GetFixedJoystickFromProvider();
        
        void SetCanvasToProvider(Canvas canvas);
        
        void SetEventSystemToProvider(EventSystem eventSystem);
        
        void SetFixedJoystickToProvider(FixedJoystick fixedJoystick);
    }
}