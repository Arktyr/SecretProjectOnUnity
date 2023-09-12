using UnityEngine;

namespace Infrastructure.Static_Data.Configs.Spawner
{
    [CreateAssetMenu(fileName = "EnemySpawnerConfig", menuName = "Configs/EnemySpawnConfig")]
    public class EnemySpawnerConfig : ScriptableObject
    {
        [field: SerializeField] public float SpawnRadius { get; private set; }
        [field: SerializeField] public float MinimumDistanceFromPlayer { get; private set; }
        [field: SerializeField] public int DelayBeforeSpawn { get; private set; }
    
        [field: SerializeField] public EnemySpawnInfo CommonEnemiesSpawnInfo{ get; private set; }
        [field: SerializeField] public EnemySpawnInfo UncommonEnemiesSpawnInfo { get; private set; }
        [field: SerializeField] public EnemySpawnInfo RareEnemiesSpawnInfo { get; private set; }
        [field: SerializeField] public EnemySpawnInfo UniqueEnemiesSpawnInfo{ get; private set; }
    }
}