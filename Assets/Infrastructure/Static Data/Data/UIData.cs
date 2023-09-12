using Infrastructure.CodeBase.UI.Buttons;
using Infrastructure.Static_Data.Configs.UI.Windows;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Infrastructure.Static_Data.Data
{
    [CreateAssetMenu(fileName = "UIData", menuName = "Data/UIData")]
    public class UIData : ScriptableObject
    {
        [field: SerializeField] public AllButtonsAnimationsConfig AllButtonsAnimationsConfig { get; private set; }
        [field: SerializeField] public AllWindowsAnimationsConfig AllWindowsAnimationsConfig { get; private set; }
    }
}