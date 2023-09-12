using UnityEngine;

namespace Infrastructure.Static_Data.Configs.UI.Buttons
{
    [CreateAssetMenu(fileName = "MainMenuButtonsAnimationsConfig", menuName = "Configs/UI/MainMenuButtonsAnimations")]
    public class MainMenuButtonsAnimationConfig : ScriptableObject
    {
        [field: SerializeField] public SelectableButtonAnimationConfig PlayButton { get; private set; }
        [field: SerializeField] public SelectableButtonAnimationConfig SettingButton { get; private set; }
        [field: SerializeField] public SelectableButtonAnimationConfig ExitButton { get; private set; }
    }
}