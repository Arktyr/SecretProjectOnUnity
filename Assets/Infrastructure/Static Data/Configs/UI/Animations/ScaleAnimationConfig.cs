using DG.Tweening;
using UnityEngine;

namespace Infrastructure.Static_Data.Configs.UI.Animations
{
    [CreateAssetMenu(fileName = "ScaleAnimationsConfig", menuName = "Configs/UI/Animations/ScaleAnimations")]
    public class ScaleAnimationConfig : ScriptableObject
    {
        [SerializeField] private Ease _ease;
        [SerializeField] private Vector3 _scale;
        [SerializeField] private float _duration;

        public Ease Ease => _ease;
        public Vector3 Scale => _scale;
        public float Duration => _duration;
    }
}