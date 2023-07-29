using Infrastructure.Static_Data.Configs.Player;
using UnityEngine;

namespace Infrastructure.Static_Data.Data
{
    [CreateAssetMenu(fileName = "CharacterData", menuName = "Data/CharacterData")]
    public class CharacterData : ScriptableObject
    {
        [field: SerializeField] public CharacterMovementConfig CharacterMovementConfig { get; private set; }
        [field: SerializeField] public CharacterStats CharacterStats { get; private set; }
    }
}