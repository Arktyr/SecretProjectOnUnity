using Cysharp.Threading.Tasks;
using Infrastructure.Gameplay.UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Infrastructure.Providers.Common
{
    public class CommonUiProvider : ICommonUIProvider
    {
        private Canvas _canvas;
        private EventSystem _eventSystem;
        private GameObject _uIRoot;

        public async UniTask<Canvas> GetCanvasFromProvider()
        {
            await UniTask.WaitUntil(() => _canvas != null);
            
            return _canvas;
        }

        public async UniTask<GameObject> GetUIRootFromProvider()
        {
            await UniTask.WaitUntil(() => _uIRoot != null);
            
            return _uIRoot;
        }

        public async UniTask<EventSystem> GetEventSystemFromProvider()
        {
            await UniTask.WaitUntil(() => _eventSystem != null);
            
            return _eventSystem;
        }
        public void SetCanvasToProvider(Canvas canvas) => _canvas = canvas;
        
        public void SetUIRootToProvider(GameObject UIRoot) => _uIRoot = UIRoot;

        public void SetEventSystemToProvider(EventSystem eventSystem) => _eventSystem = eventSystem;
    }
}