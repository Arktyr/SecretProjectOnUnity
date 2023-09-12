using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Infrastructure.Providers.Common
{
    public interface ICommonUIProvider
    {
        UniTask<Canvas> GetCanvasFromProvider();
        UniTask<GameObject> GetUIRootFromProvider();
        
        UniTask<EventSystem> GetEventSystemFromProvider();
        
        void SetCanvasToProvider(Canvas canvas);
        void SetUIRootToProvider(GameObject UIRoot);
        
        void SetEventSystemToProvider(EventSystem eventSystem);
    }
}