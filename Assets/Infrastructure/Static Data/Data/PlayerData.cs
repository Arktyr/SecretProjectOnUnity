using Infrastructure.Static_Data.Configs;
using Infrastructure.Static_Data.Configs.Player;
using UnityEngine;

namespace Infrastructure.Static_Data.Data
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "Data/PlayerData")]
    public class PlayerData : ScriptableObject
    {
        [field: SerializeField] public CharacterData CharacterData { get; private set; }
   
        [field: SerializeField] public PlayerTeleportConfig PlayerTeleport { get; private set; }
    }
}