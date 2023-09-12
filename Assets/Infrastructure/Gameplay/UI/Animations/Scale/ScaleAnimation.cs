using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Infrastructure.Static_Data.Configs.UI.Animations;
using UnityEngine;

namespace Infrastructure.Gameplay.UI.Animations.ButtonAnimation
{
    public class ScaleAnimation : IScaleAnimation
    {
        public async UniTask GetScale(ScaleAnimationConfig animationConfig, Transform transform)
        {
            Vector3 scale = animationConfig.Scale;
            
            float duration = animationConfig.Duration;
            
            Ease ease = animationConfig.Ease;
            
            Tweener tweener = transform
                .DOScale(scale, duration)
                .SetEase(ease)
                .SetUpdate(true);

            await tweener.Play().ToUniTask();
        }
    }
}