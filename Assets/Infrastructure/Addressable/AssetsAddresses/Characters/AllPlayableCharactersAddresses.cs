using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Infrastructure.Addressable.AssetsAddresses.Characters
{
    [CreateAssetMenu(fileName = "AllPlayableCharactersAddresses", 
        menuName = "Addresses/Characters/AllPlayableCharacters")]
    public class AllPlayableCharactersAddresses : ScriptableObject
    {
        [field: SerializeField] public AssetReferenceGameObject CommonCharacter { get; private set; }
    }
}