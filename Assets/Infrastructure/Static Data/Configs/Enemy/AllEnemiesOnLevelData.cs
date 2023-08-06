using UnityEngine;

namespace Infrastructure.Static_Data.Configs.Enemy
{
    [CreateAssetMenu(fileName = "AllEnemiesOnLevelConfig", menuName = "Configs/Enemies/AllEnemiesOnLevelConfig")]
    public class AllEnemiesOnLevelData : ScriptableObject
    {
        [field: SerializeField] public EnemyConfig[] CommonEnemies { get; private set; }
        [field: SerializeField] public EnemyConfig[] UncommonEnemies { get; private set; }
        [field: SerializeField] public EnemyConfig[] RareEnemies { get; private set; }
        [field: SerializeField] public EnemyConfig[] UniqueEnemies { get; private set; }
    }
}