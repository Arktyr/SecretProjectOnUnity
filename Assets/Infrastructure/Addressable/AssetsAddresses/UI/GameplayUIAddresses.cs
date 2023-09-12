using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Infrastructure.Addressable.AssetsAddresses.UI
{
    [CreateAssetMenu(fileName = "GameplayUIAddresses", menuName = "Addresses/UI/GameplayUI")]
    public class GameplayUIAddresses : ScriptableObject
    {
        [field: SerializeField] public AssetReferenceGameObject PlayTimer { get; private set;}
        
        [field: SerializeField] public AssetReferenceGameObject HealthBar { get; private set;}
        
        [field: SerializeField] public AssetReferenceGameObject HealthBarFiller { get; private set;}
        
        [field: SerializeField] public AssetReferenceGameObject FPSCounter { get; private set; }
    }
}