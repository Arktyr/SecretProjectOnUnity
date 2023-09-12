using Cysharp.Threading.Tasks;
using Infrastructure.Static_Data.Configs.UI.Animations;
using UnityEngine;
using UnityEngine.UI;

namespace Infrastructure.Gameplay.UI.Animations.Window
{
    public interface IUIAnimation
    {
        public UniTask Play(ScaleAnimationConfig scaleAnimationConfig,
            FadeAnimationConfig fadeAnimationConfig,
            Image image, 
            GameObject prefab);
        public UniTask Play(FadeAnimationConfig fadeAnimationConfig,
            Image image);
        public UniTask Play(ScaleAnimationConfig scaleAnimationConfig,
            GameObject windowPrefab);

    }
}