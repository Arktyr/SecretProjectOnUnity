using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Infrastructure.Addressable.AssetsAddresses.UI
{
    [CreateAssetMenu(menuName = "Addresses/UI/LoadScreenUIAddresses", fileName = "LoadScreenUIAddresses")]
    public class LoadScreenUIAddresses : ScriptableObject
    {
        [field: SerializeField] public AssetReferenceGameObject LoadScreenWindow { get; private set; }
        [field: SerializeField] public AssetReferenceGameObject LoadingFiller { get; private set; }
    }
}