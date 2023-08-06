using Cysharp.Threading.Tasks;
using Infrastructure.Gameplay.Persons.PlayerUncontrolled;
using Infrastructure.Static_Data.Configs.Enemy;

namespace Infrastructure.Factories.EnemiesFactory
{
    public interface IEnemyFactory
    {
        public UniTask<IEnemy> CreateUniqueEnemy(EnemyConfig enemyConfig);
        
        public UniTask<IEnemy> CreateRareEnemy(EnemyConfig enemyConfig);

        public UniTask<IEnemy> CreateUncommonEnemy(EnemyConfig enemyConfig);
        
        public UniTask<IEnemy> CreateCommonEnemy(EnemyConfig enemyConfig);

    }
}