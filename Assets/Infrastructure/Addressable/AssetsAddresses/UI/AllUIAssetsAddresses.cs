using UnityEngine;

namespace Infrastructure.Addressable.AssetsAddresses.UI
{
    [CreateAssetMenu(fileName = "AllUIAssetsAddresses", menuName = "Addresses/AllUIAssets")]
    public class AllUIAssetsAddresses : ScriptableObject
    {
        [field: SerializeField] public InputAssetsAddresses InputAssetsAddresses { get; private set; }
        
        [field: SerializeField] public CommonUIAddresses CommonUIAddresses { get; private set; }
    }
}