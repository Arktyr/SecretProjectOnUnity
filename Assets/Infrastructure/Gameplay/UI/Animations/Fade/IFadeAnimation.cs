using Cysharp.Threading.Tasks;
using Infrastructure.Static_Data.Configs.UI.Animations;
using UnityEngine;
using UnityEngine.UI;

namespace Infrastructure.Gameplay.UI.Animations.ButtonAnimation
{
    public interface IFadeAnimation
    {
        UniTask FadeTask(FadeAnimationConfig fadeAnimationConfig,
            Image image);

         void Fade(FadeAnimationConfig fadeAnimationConfig,
            Image image);
    }
}