using Cysharp.Threading.Tasks;
using DG.Tweening;
using Infrastructure.Static_Data.Configs.UI.Animations;
using UnityEngine.UI;

namespace Infrastructure.Gameplay.UI.Animations.ButtonAnimation
{
    public class FadeAnimation : IFadeAnimation
    {
        public async UniTask FadeTask(FadeAnimationConfig fadeAnimationConfig,
            Image image) =>
            await GetFade(fadeAnimationConfig, image).Play().ToUniTask();

        public void Fade(FadeAnimationConfig fadeAnimationConfig,
            Image image) =>
            GetFade(fadeAnimationConfig, image).Play();

        private Tweener GetFade(FadeAnimationConfig fadeAnimationConfig,
            Image image)
        {
            float duration = fadeAnimationConfig.Duration;

            float fade = fadeAnimationConfig.EndValue;

            Ease ease = fadeAnimationConfig.Ease;

            Tweener tweener = image
                .DOFade(fade, duration)
                .SetUpdate(true)
                .SetEase(ease);

            return tweener;
        }
    }
}