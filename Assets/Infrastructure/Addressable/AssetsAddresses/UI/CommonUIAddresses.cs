using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Infrastructure.Addressable.AssetsAddresses.UI
{
    [CreateAssetMenu(fileName = "CommonUIAssetsAddresses", menuName = "Addresses/UI/CommonAssets")]
    public class CommonUIAddresses : ScriptableObject
    {
        [field: SerializeField] public AssetReferenceGameObject CanvasPrefab { get; private set; }

        [field: SerializeField] public AssetReferenceGameObject EventSystemPrefab { get; private set; }
    }
}