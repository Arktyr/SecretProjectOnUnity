using UnityEngine;

namespace Infrastructure.Static_Data.Configs.Player
{
    [CreateAssetMenu(fileName = "CharacterTeleportConfig", menuName = "Configs/CharacterTeleportConfig")]
    public class CharacterTeleportConfig : ScriptableObject
    {
        [field: SerializeField] public float TeleportDistance { get; private set; }
        
        [field: SerializeField] public int TeleportCooldown { get; private set; }
    }
}