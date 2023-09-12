using Zenject;

namespace Infrastructure.Gameplay.Spawner
{
    public interface IEnemySpawner : IInitializable
    {
        public void StartSpawnEnemies();

        public void StopSpawnEnemies();
    }
}