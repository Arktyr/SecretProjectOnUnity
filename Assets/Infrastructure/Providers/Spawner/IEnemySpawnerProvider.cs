using Cysharp.Threading.Tasks;
using Infrastructure.Gameplay.Spawner;

namespace Infrastructure.Providers.Spawner
{
    public interface IEnemySpawnerProvider
    {
        public UniTask<IEnemySpawner> GetEnemySpawnerFromProvider();

        public void SetEnemySpawnerToProvider(IEnemySpawner enemySpawner);
    }
}