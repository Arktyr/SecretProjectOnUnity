using Infrastructure.Static_Data.Configs.Enemy;
using Infrastructure.Static_Data.Configs.Spawner;
using UnityEngine;

namespace Infrastructure.Static_Data.Data
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "Data/LevelData")]
    public class LevelData : ScriptableObject
    {
        [field:SerializeField] public AllEnemiesOnLevelData AllEnemiesOnLevelData { get; private set; }
        [field:SerializeField] public Vector3 MapSize { get; private set; }
        
        [field:SerializeField] public EnemySpawnerConfig EnemySpawnerConfig { get; private set; }
    }
}