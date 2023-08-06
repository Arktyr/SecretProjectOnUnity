using UnityEngine;

namespace Infrastructure.Addressable.AssetsAddresses.Characters
{
    [CreateAssetMenu(fileName = "AllUnPlayableCharactersAddresses", 
        menuName = "Addresses/Characters/AllUnPlayableCharacters")]
    public class AllUnPlayableCharactersAddresses : ScriptableObject
    {
        [field: SerializeField] public CommonEnemyAddresses _commonEnemyAddresses { get; private set;}

    }
}