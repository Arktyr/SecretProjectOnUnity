using Infrastructure.Addressable.AssetsAddresses.Characters;
using Infrastructure.Addressable.AssetsAddresses.Player;
using Infrastructure.Addressable.AssetsAddresses.UI;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Infrastructure.Addressable.AssetsAddresses
{
    [CreateAssetMenu(fileName = "AllAssetsAddresses", menuName = "Addresses/AllAssets")]
    public class AllAssetsAddresses : ScriptableObject
    {
        [field: SerializeField] public PlayerAssetsAddresses PlayerAssetsAddresses { get; private set; }
        
        [field: SerializeField] public AllCharacterAddresses AllCharacterAddresses { get; private set; }
        
        [field: SerializeField] public AllUIAssetsAddresses AllUIAssetsAddresses { get; private set; }
        
        [field: SerializeField] public AssetReferenceGameObject ColliderWatcher { get; private set; }
    }
}