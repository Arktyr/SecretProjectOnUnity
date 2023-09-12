using Infrastructure.Static_Data.Configs.UI.Buttons;
using UnityEngine;

namespace Infrastructure.CodeBase.UI.Buttons
{
    [CreateAssetMenu(fileName = "PauseMenuButtonsAnimationsConfig", menuName = "Configs/UI/PauseMenuButtonsAnimations")]
    public class PauseMenuButtonsAnimationConfig : ScriptableObject
    {
        [field: SerializeField] public SelectableButtonAnimationConfig ResumeButton { get; private set; }
        [field: SerializeField] public SelectableButtonAnimationConfig SettingButton { get; private set; }
        [field: SerializeField] public SelectableButtonAnimationConfig ReturnToMainMenuButton { get; private set; }
        [field: SerializeField] public SelectableButtonAnimationConfig PauseButton { get; private set; }
    }
}