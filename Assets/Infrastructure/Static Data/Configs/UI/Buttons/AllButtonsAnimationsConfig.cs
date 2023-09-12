using Infrastructure.Static_Data.Configs.UI.Buttons;
using UnityEngine;

namespace Infrastructure.CodeBase.UI.Buttons
{
    [CreateAssetMenu(fileName = "AllButtonsAnimationsConfig", menuName = "Configs/UI/AllButtonsAnimations")]
    public class AllButtonsAnimationsConfig : ScriptableObject
    {
        [field: SerializeField] public MainMenuButtonsAnimationConfig MainMenuButtonsAnimationConfig 
        {get; private set;}
        [field: SerializeField] public PauseMenuButtonsAnimationConfig PauseMenuButtonsAnimationConfig 
        {get; private set;
        }
        
    }
}