using Cysharp.Threading.Tasks;
using Infrastructure.Gameplay.Timer;
using Infrastructure.Gameplay.UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Infrastructure.Providers
{
    public interface IUIProvider
    {
        UniTask<FixedJoystick> GetFixedJoystickFromProvider();
        UniTask<IPlayTimerUI> GetPlayTimerUIFromProvider();
        void SetFixedJoystickToProvider(FixedJoystick fixedJoystick);
        void SetPlayTimerUIToProvider(IPlayTimerUI playTimer);
    }
}