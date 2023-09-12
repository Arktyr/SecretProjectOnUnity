using Infrastructure.Static_Data.Configs.UI.Animations;
using UnityEngine;

namespace Infrastructure.Static_Data.Configs.UI.Windows
{
    [CreateAssetMenu(fileName = "PauseMenuWindowConfig", menuName = "Configs/UI/PauseMenuWindow")]
    public class WindowAnimationConfig : ScriptableObject
    {
        [field: SerializeField] public ScaleAnimationConfig AnimationConfigIn { get; private set; }
        [field: SerializeField] public ScaleAnimationConfig AnimationConfigOut { get; private set; }
        [field: SerializeField] public FadeAnimationConfig FadeAnimationConfigIn { get; private set; }
        [field: SerializeField] public FadeAnimationConfig FadeAnimationConfigOut { get; private set; }
    }
}