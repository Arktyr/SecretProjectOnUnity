using Infrastructure.Gameplay.UI.Animations.ButtonAnimation.ButtonAnimation;
using Infrastructure.Gameplay.UI.Animations.Window;
using Infrastructure.Static_Data.Configs.UI.Animations;
using Infrastructure.Static_Data.Configs.UI.Buttons;
using UnityEngine;

namespace Infrastructure.Gameplay.UI.Animations.ButtonAnimation
{
    public class SelectableButtonAnimation : ISelectableButtonAnimation
    {
        private GameObject _buttonPrefab;

        private readonly IUIAnimation _uiAnimation;
        
        private ScaleAnimationConfig _configOnEnter;
        private ScaleAnimationConfig _configOnExit;
        private ScaleAnimationConfig _configOnDown;
        private ScaleAnimationConfig _configOnUp;
        
        public SelectableButtonAnimation(IUIAnimation uiAnimation)
        {
            _uiAnimation = uiAnimation;
        }

        public void Construct(GameObject buttonPrefab, 
            SelectableButtonAnimationConfig selectableButtonAnimation)
        {
            _buttonPrefab = buttonPrefab;

            _configOnEnter = selectableButtonAnimation.AnimationOnEnter;
            _configOnExit = selectableButtonAnimation.AnimationOnExit;
            _configOnDown = selectableButtonAnimation.AnimationOnDown;
            _configOnUp = selectableButtonAnimation.AnimationOnUp;
        }

        public void StartAnimation(PointerStatus pointerStatus)
        {
            switch (pointerStatus)
            {
                case PointerStatus.OnEnter: _uiAnimation.Play(_configOnEnter, _buttonPrefab);
                    break;
                case PointerStatus.OnExit: _uiAnimation.Play(_configOnExit, _buttonPrefab);
                    break;
                case PointerStatus.OnDown: _uiAnimation.Play(_configOnDown, _buttonPrefab);
                    break;
                case PointerStatus.OnUp: _uiAnimation.Play(_configOnUp, _buttonPrefab);
                    break;
                default:
                    Debug.LogError($"{pointerStatus}, doesnt exist");
                    break;
            }
        }

    }
}