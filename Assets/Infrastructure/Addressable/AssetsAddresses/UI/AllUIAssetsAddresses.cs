using UnityEngine;

namespace Infrastructure.Addressable.AssetsAddresses.UI
{
    [CreateAssetMenu(fileName = "AllUIAssetsAddresses", menuName = "Addresses/AllUIAssets")]
    public class AllUIAssetsAddresses : ScriptableObject
    {
        [field: SerializeField] public InputAssetsAddresses InputAssetsAddresses { get; private set; }
        [field: SerializeField] public CommonUIAddresses CommonUIAddresses { get; private set; }
        [field: SerializeField] public GameplayUIAddresses GameplayUIAddresses { get; private set; }
        [field: SerializeField] public MainMenuUIAddresses MainMenuUIAddresses { get; private set; }
        [field: SerializeField] public PauseMenuUIAddresses PauseMenuUIAddresses { get; private set; }
        
        [field: SerializeField] public LoadScreenUIAddresses LoadScreenUIAddresses { get; private set; }
    }
}