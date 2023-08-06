using Cysharp.Threading.Tasks;
using Infrastructure.CodeBase.Services.Update;
using Infrastructure.Gameplay.Persons.Common.Abilities;
using Infrastructure.Gameplay.Persons.PlayerUncontrolled;
using Infrastructure.Providers;
using UnityEngine;

namespace Infrastructure.Gameplay.Spawner
{
    public class EnemySpawner : IEnemySpawner
    {
        private readonly IEnemyPool _enemyPool;

        private readonly IStaticDataProvider _staticDataProvider;
        private readonly IUpdaterService _updaterService;
        private readonly ICooldown _cooldown;

        public EnemySpawner(IEnemyPool enemyPool,
            IStaticDataProvider staticDataProvider,
            IUpdaterService updaterService)
        {
            _staticDataProvider = staticDataProvider;
            _enemyPool = enemyPool;
            _updaterService = updaterService;

            Cooldown cooldown = new Cooldown();
            cooldown.Construct(_staticDataProvider.LevelData.EnemySpawnerConfig.DelayBeforeSpawn);
            _cooldown = cooldown;
        }

        public void StartSpawnEnemies() => _updaterService.FixedUpdate += Update;

        public void StopSpawnEnemies() => _updaterService.FixedUpdate -= Update;

        private async void Update(float time)
        {
            if (_cooldown.IsRecharged) await SpawnEnemies();
        }
        
        private async UniTask SpawnEnemies()
        {
            await _cooldown.StartCooldown();
            
            if (TryToSpawn(_staticDataProvider.LevelData.EnemySpawnerConfig.ChanceToSpawnUncommonEnemies))
                await SpawnEnemy(EnemyType.UncommonEnemy);

            if (TryToSpawn(_staticDataProvider.LevelData.EnemySpawnerConfig.ChanceToSpawnRareEnemies))
                await SpawnEnemy(EnemyType.RareEnemy);

            if (TryToSpawn(_staticDataProvider.LevelData.EnemySpawnerConfig.ChanceToSpawnUniqueEnemies))
                await SpawnEnemy(EnemyType.UniqueEnemy);
            
            await SpawnEnemy(EnemyType.CommonEnemy);
        }

        private bool TryToSpawn(int chance)
        {
            float random = Random.Range(0, 101);
            
            return chance >= random;
        }

        private async UniTask SpawnEnemy(EnemyType enemyType)
        {
            IEnemy enemy = await _enemyPool.Take(enemyType);
            
            enemy.SubscribeToEvents();
            enemy.Character.CharacterInjuring.Health.Heal(float.MaxValue);

            enemy.Character.CharacterPrefab.transform.position = GetRandomPositionToSpawn();
        }

        private Vector3 GetRandomPositionToSpawn()
        {
           Vector2 randomPosition = 
               Random.insideUnitCircle * _staticDataProvider.LevelData.EnemySpawnerConfig.SpawnRadius;

           return new Vector3(randomPosition.x, 1, randomPosition.y);
        }
    }
}