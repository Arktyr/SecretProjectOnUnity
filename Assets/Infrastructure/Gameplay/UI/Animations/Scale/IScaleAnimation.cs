using Cysharp.Threading.Tasks;
using DG.Tweening;
using Infrastructure.Static_Data.Configs.UI.Animations;
using UnityEngine;

namespace Infrastructure.Gameplay.UI.Animations.ButtonAnimation
{
    public interface IScaleAnimation
    {
        UniTask GetScale(ScaleAnimationConfig animationConfig, Transform transform);
    }
}