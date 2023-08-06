using UnityEngine;

namespace Infrastructure.Static_Data.Configs.Spawner
{
    
    [CreateAssetMenu(fileName = "EnemySpawnerConfig", menuName = "Configs/EnemySpawnConfig")]
    public class EnemySpawnerConfig : ScriptableObject
    {
        [field: SerializeField] public float SpawnRadius { get; private set; }
        
        [field: SerializeField] public int DelayBeforeSpawn { get; private set; }

        [field: SerializeField] public int ChanceToSpawnCommonEnemies { get; private set; }
        [field: SerializeField] public int ChanceToSpawnUncommonEnemies { get; private set; }
        [field: SerializeField] public int ChanceToSpawnRareEnemies { get; private set; }
        [field: SerializeField] public int ChanceToSpawnUniqueEnemies { get; private set; }
    }
}