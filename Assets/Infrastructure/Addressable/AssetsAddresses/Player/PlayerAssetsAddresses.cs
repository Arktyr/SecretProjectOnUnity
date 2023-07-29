using UnityEngine;

namespace Infrastructure.Addressable.AssetsAddresses.Player
{
    [CreateAssetMenu(fileName = "PlayerAssetsAddresses", menuName = "Addresses/Player/PlayerAssets")]
    public class PlayerAssetsAddresses : ScriptableObject
    {
        [field: SerializeField] public CameraAssetsAddresses CameraAssetsAddresses { get; private set; }
    }
}