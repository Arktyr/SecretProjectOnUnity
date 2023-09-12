using Cysharp.Threading.Tasks;
using Infrastructure.Gameplay.UI.Animations.ButtonAnimation;
using Infrastructure.Gameplay.UI.Animations.Window;
using Infrastructure.Static_Data.Configs.UI.Animations;
using Infrastructure.Static_Data.Configs.UI.Windows;
using UnityEngine;

namespace Infrastructure.Gameplay.UI.Windows
{
    public class PauseWindowLogic : IWindowLogic
    {
        private readonly IUIAnimation _uiAnimation;
        
        private GameObject _windowPrefab;
        private WindowAnimationConfig _config;
        
        public PauseWindowLogic(IUIAnimation uiAnimation)
        {
            _uiAnimation = uiAnimation;
        }
        
        public void Construct(GameObject windowPrefab,
            WindowAnimationConfig config)
        {
            _windowPrefab = windowPrefab;
            _config = config;
        }

        public async UniTask Enable()
        {
            _windowPrefab.SetActive(true);

            await _uiAnimation.Play(_config.AnimationConfigIn, _windowPrefab);
        }

        public async UniTask Disable()
        {
            _windowPrefab.SetActive(false);
            
            await _uiAnimation.Play(_config.AnimationConfigOut, _windowPrefab);
        }
    }
}