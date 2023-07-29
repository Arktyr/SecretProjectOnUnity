using UnityEngine;

namespace Infrastructure.Static_Data.Configs.Player
{
    [CreateAssetMenu(fileName = "PlayerTeleportConfig", menuName = "Configs/PlayerTeleportConfig")]
    public class PlayerTeleportConfig : ScriptableObject
    {
        [field: SerializeField] public float TeleportDistance { get; private set; }
        
        [field: SerializeField] public int TeleportCooldown { get; private set; }
    }
}