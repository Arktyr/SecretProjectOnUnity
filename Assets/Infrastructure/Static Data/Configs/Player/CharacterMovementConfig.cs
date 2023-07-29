using UnityEngine;

namespace Infrastructure.Static_Data.Configs.Player
{
    [CreateAssetMenu(fileName = "CharacterMovementConfig", menuName = "Configs/CharacterMovementConfig")]
    public class CharacterMovementConfig : ScriptableObject
    {
        [field: SerializeField] public float Speed { get; private set; }
        
        [field: SerializeField] public float RotateTime { get; private set; }
    }
}