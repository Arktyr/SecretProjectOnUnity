using UnityEngine;

namespace Infrastructure.Static_Data.Configs.UI.Windows
{
    [CreateAssetMenu(fileName = "AllWindowsAnimationConfig", menuName = "Configs/UI/AllWindowsAnimation")]
    public class AllWindowsAnimationsConfig : ScriptableObject
    {
        [field: SerializeField] public WindowAnimationConfig PauseMenuWindowConfig { get; private set; }
        
        [field: SerializeField] public WindowAnimationConfig LoadScreenWindowConfig { get; private set; }
    }
}