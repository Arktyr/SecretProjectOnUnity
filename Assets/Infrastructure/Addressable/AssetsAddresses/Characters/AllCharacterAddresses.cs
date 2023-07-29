using UnityEngine;

namespace Infrastructure.Addressable.AssetsAddresses.Characters
{
    [CreateAssetMenu(fileName = "AllCharactersAddresses", menuName = "Addresses/Characters/AllCharacters")]
    public class AllCharacterAddresses : ScriptableObject
    {
        [field: SerializeField] public AllPlayableCharactersAddresses AllPlayableCharactersAddresses { get; private set;}
        
        [field: SerializeField] public AllUnPlayableCharactersAddresses AllUnPlayableCharactersAddresses { get; private set;}
    }
}