using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Infrastructure.Addressable.AssetsAddresses.UI
{
    [CreateAssetMenu(fileName = "MainMenuUIAddresses", menuName = "Addresses/UI/MainMenuUI")]
    public class MainMenuUIAddresses : ScriptableObject
    {
        [field: SerializeField] public AssetReferenceGameObject MainMenuWindow { get; private set;}
        [field: SerializeField] public AssetReferenceGameObject PlayButton { get; private set;}
        [field: SerializeField] public AssetReferenceGameObject SettingsButton { get; private set;}
        [field: SerializeField] public AssetReferenceGameObject QuitButton { get; private set;}
    }
}