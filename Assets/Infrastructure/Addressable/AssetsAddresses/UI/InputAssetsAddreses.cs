using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Infrastructure.Addressable.AssetsAddresses.UI
{
    [CreateAssetMenu(fileName = "InputAssetsAddresses", menuName = "Addresses/UI/InputAssets")]
    public class InputAssetsAddresses : ScriptableObject
    {
        [field: SerializeField] public AssetReferenceGameObject JoyStick { get; private set; }
    }
}