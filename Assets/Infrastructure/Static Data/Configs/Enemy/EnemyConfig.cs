using Infrastructure.Gameplay.Persons.Common.Abilities;
using Infrastructure.Gameplay.Persons.PlayerUncontrolled;
using Infrastructure.Static_Data.Data;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Infrastructure.Static_Data.Configs.Enemy
{
    [CreateAssetMenu(fileName = "EnemyConfig", menuName = "Configs/Enemies/EnemyConfig")]
    public class EnemyConfig : ScriptableObject
    {
        [field: SerializeField] public GameObject EnemyPrefab { get; private set; }
        [field: SerializeField] public AssetReferenceGameObject EnemyAddress { get; private set; }
        [field: SerializeField] public CharacterData CharacterData { get; private set; }
        
        [field: SerializeField] public EnemyType EnemyType { get; private set; }
    }
}