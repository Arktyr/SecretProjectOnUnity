using Cysharp.Threading.Tasks;
using Infrastructure.Gameplay.UI.Animations.Window;
using Infrastructure.Static_Data.Configs.UI.Windows;
using UnityEngine;
using UnityEngine.UI;

namespace Infrastructure.Gameplay.UI.Windows.LoadScreen
{
    public class LoadScreenLogic : IWindowLogic
    {
        private readonly IUIAnimation _uiAnimation;

        private GameObject _windowPrefab;
        private Image _windowImage;

        private WindowAnimationConfig _windowAnimationConfig;

        public LoadScreenLogic(IUIAnimation uiAnimation)
        {
            _uiAnimation = uiAnimation;
        }
        
        public void Construct(GameObject windowPrefab,
            WindowAnimationConfig windowAnimationConfig)
        {
            _windowPrefab = windowPrefab;
            _windowImage = _windowPrefab.GetComponentInChildren<Image>();

            _windowAnimationConfig = windowAnimationConfig;
        }

        public void ResetAlphaColor() => _windowImage.color =
            new Color(_windowImage.color.r, _windowImage.color.g, _windowImage.color.b, 0);

        public async UniTask Enable()
        {
            _windowPrefab.SetActive(true);
            
            await _uiAnimation.Play(_windowAnimationConfig.FadeAnimationConfigIn, _windowImage);
        }

        public async UniTask Disable()
        {
            await _uiAnimation.Play(_windowAnimationConfig.FadeAnimationConfigOut, _windowImage);
            
            _windowPrefab.SetActive(false);
        }
    }
}