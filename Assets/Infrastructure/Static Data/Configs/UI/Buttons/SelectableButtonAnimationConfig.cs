using Infrastructure.Static_Data.Configs.UI.Animations;
using UnityEngine;

namespace Infrastructure.Static_Data.Configs.UI.Buttons
{
    [CreateAssetMenu(fileName = "SelectableButtonAnimationConfig", menuName = "Configs/UI/SelectableButtonAnimation")]
    public class SelectableButtonAnimationConfig : ScriptableObject
    {
        [Header("OnPointerDown")]
        [SerializeField] private ScaleAnimationConfig animationOnDown;

        public ScaleAnimationConfig AnimationOnDown => animationOnDown;
        
        [Header("OnPointerUp")]
        [SerializeField] private ScaleAnimationConfig animationOnUp;
        
        public ScaleAnimationConfig AnimationOnUp => animationOnUp;
        
        [Header("OnPointerEnter")]
        [SerializeField] private ScaleAnimationConfig animationOnEnter;
        
        public ScaleAnimationConfig AnimationOnEnter => animationOnEnter;
        
        [Header("OnPointerExit")]
        [SerializeField] private ScaleAnimationConfig animationOnExit;
        
        public ScaleAnimationConfig AnimationOnExit => animationOnExit;
    }
}