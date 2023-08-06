using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Infrastructure.Addressable.AssetsAddresses.Characters
{
    [CreateAssetMenu(fileName = "CommonEnemyAddresses", 
        menuName = "Addresses/Characters/CommonEnemy")]
    public class CommonEnemyAddresses : ScriptableObject
    {
        [field: SerializeField] public AssetReferenceGameObject FirstVariant { get; private set; }
    }
}