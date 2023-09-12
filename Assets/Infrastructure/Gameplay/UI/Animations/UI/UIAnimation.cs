using Cysharp.Threading.Tasks;
using Infrastructure.Gameplay.UI.Animations.ButtonAnimation;
using Infrastructure.Static_Data.Configs.UI.Animations;
using Infrastructure.Static_Data.Configs.UI.Windows;
using UnityEngine;
using UnityEngine.UI;

namespace Infrastructure.Gameplay.UI.Animations.Window
{
    public class UIAnimation : IUIAnimation
    {
        private readonly IScaleAnimation _scaleAnimation;
        private readonly IFadeAnimation _fadeAnimation;

        public UIAnimation(IScaleAnimation scaleAnimation, 
            IFadeAnimation fadeAnimation)
        {
            _scaleAnimation = scaleAnimation;
            _fadeAnimation = fadeAnimation;
        }
        
        public async UniTask Play(ScaleAnimationConfig scaleAnimationConfig, 
            FadeAnimationConfig fadeAnimationConfig,
            Image image,
            GameObject windowPrefab)
        {
            _fadeAnimation.Fade(fadeAnimationConfig, image);
            await _scaleAnimation.GetScale(scaleAnimationConfig, windowPrefab.transform);
        }

        public async UniTask Play(FadeAnimationConfig fadeAnimationConfig, 
            Image image) =>
            await _fadeAnimation.FadeTask(fadeAnimationConfig, image);

        public async UniTask Play(ScaleAnimationConfig scaleAnimationConfig,
            GameObject windowPrefab) =>
            await _scaleAnimation.GetScale(scaleAnimationConfig, windowPrefab.transform);
    }
}