using DG.Tweening;
using UnityEngine;

namespace Infrastructure.Static_Data.Configs.UI.Animations
{
[CreateAssetMenu(fileName = "FadeAnimationsConfig", menuName = "Configs/UI/Animations/FadeAnimations")]
    public class FadeAnimationConfig : ScriptableObject
    {
        [field: SerializeField] public float EndValue { get; private set; }
        [field: SerializeField] public float Duration { get; private set; }
        [field: SerializeField] public Ease Ease { get; private set; }
    }
}