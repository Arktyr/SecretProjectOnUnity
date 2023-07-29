using UnityEngine;

namespace Infrastructure.Static_Data.Data
{
    [CreateAssetMenu(fileName = "CharacterStatsConfig", menuName = "Configs/CharacterStatsConfig")]
    public class CharacterStats : ScriptableObject
    {
        [field: SerializeField] public float Health { get; private set; }
        [field: SerializeField] public float MaxHealth { get; private set; }
    }
}