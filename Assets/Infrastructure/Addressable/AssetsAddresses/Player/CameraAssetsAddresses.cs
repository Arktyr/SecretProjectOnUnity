using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Infrastructure.Addressable.AssetsAddresses.Player
{
    [CreateAssetMenu(fileName = "CameraAssetsAddresses", menuName = "Addresses/Camera/CameraAssets")]
    public class CameraAssetsAddresses : ScriptableObject
    {
        [field: SerializeField] public AssetReferenceGameObject Camera { get; private set; }
    }
}