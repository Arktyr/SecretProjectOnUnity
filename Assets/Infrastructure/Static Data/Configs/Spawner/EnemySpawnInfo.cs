using UnityEngine;

namespace Infrastructure.Static_Data.Configs.Spawner
{
    [CreateAssetMenu(fileName = "EnemySpawnInfo", menuName = "Configs/EnemySpawnInfo")]
    public class EnemySpawnInfo : ScriptableObject
    {
        [field: SerializeField] public int TimeBeforeSpawnEnemy { get; private set; }
        
        [field: SerializeField] public int ChanceToSpawnEnemy { get; private set; }
    }
}