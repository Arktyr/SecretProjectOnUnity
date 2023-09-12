using Cysharp.Threading.Tasks;
using Infrastructure.Gameplay.Spawner;

namespace Infrastructure.Providers.Spawner
{
    public class EnemySpawnerProvider : IEnemySpawnerProvider
    {
        private IEnemySpawner _enemySpawner;
        
        public async UniTask<IEnemySpawner> GetEnemySpawnerFromProvider()
        {
            await UniTask.WaitUntil(() => _enemySpawner != null);
            
            return _enemySpawner;
        }
        
        public void SetEnemySpawnerToProvider(IEnemySpawner enemySpawner) => _enemySpawner = enemySpawner;
    }
}