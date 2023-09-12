using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Infrastructure.Addressable.AssetsAddresses.UI
{
    [CreateAssetMenu(fileName = "PauseMenuUIAddresses", menuName = "Addresses/UI/PauseMenuUI")]
    public class PauseMenuUIAddresses : ScriptableObject
    {
        [field: SerializeField] public AssetReferenceGameObject PauseWindow { get; private set;}
        [field: SerializeField] public AssetReferenceGameObject PauseButton { get; private set;}
        [field: SerializeField] public AssetReferenceGameObject ResumeButton { get; private set;}
        [field: SerializeField] public AssetReferenceGameObject SettingsButton { get; private set;}
        [field: SerializeField] public AssetReferenceGameObject ReturnToMainMenuButton { get; private set;}
    }
}