using Cysharp.Threading.Tasks;
using Infrastructure.CodeBase.Services.Update;
using Infrastructure.Gameplay.Persons.Common.Abilities;
using Infrastructure.Gameplay.Persons.PlayerUncontrolled;
using Infrastructure.Gameplay.Timer;
using Infrastructure.Providers;
using Infrastructure.Providers.Spawner;
using Infrastructure.Static_Data.Configs.Spawner;
using UnityEngine;

namespace Infrastructure.Gameplay.Spawner
{
    public class EnemySpawner : IEnemySpawner
    {
        private readonly IEnemyPool _enemyPool;
        
        private readonly EnemySpawnerConfig _enemySpawnerConfig;
        
        private readonly IUpdaterService _updaterService;
        private readonly ICooldown _cooldown;
        private readonly IPlayTimer _playTimer;

        private readonly IPlayerProvider _playerProvider;

        private readonly IEnemySpawnerProvider _enemySpawnerProvider;
        
        private const float OnGround = 1;

        public EnemySpawner(IEnemyPool enemyPool,
            IStaticDataProvider staticDataProvider,
            IUpdaterService updaterService,
            IPlayerProvider playerProvider,
            IPlayTimer playTimer,
            IEnemySpawnerProvider enemySpawnerProvider)
        {
            _enemySpawnerConfig = staticDataProvider.LevelData.EnemySpawnerConfig;
            _enemyPool = enemyPool;
            _updaterService = updaterService;
            _playerProvider = playerProvider;
            _playTimer = playTimer;
            _enemySpawnerProvider = enemySpawnerProvider;

            Cooldown cooldown = new Cooldown();
            cooldown.Construct(_enemySpawnerConfig.DelayBeforeSpawn);
            _cooldown = cooldown;
        }

        public void StartSpawnEnemies()
        {
            _updaterService.Update += Update;
        }

        public void StopSpawnEnemies()
        {
            _updaterService.Update -= Update;
        }

        private async void Update(float time)
        {
            if (_cooldown.IsRecharged) await SpawnEnemies();
        }
        
        private async UniTask SpawnEnemies()
        {
            await _cooldown.StartCooldown();
            
            if (TryToSpawn(_enemySpawnerConfig.UncommonEnemiesSpawnInfo))
                await SpawnEnemy(EnemyType.UncommonEnemy);
            
            if (TryToSpawn(_enemySpawnerConfig.RareEnemiesSpawnInfo))
                await SpawnEnemy(EnemyType.RareEnemy);

            if (TryToSpawn(_enemySpawnerConfig.UniqueEnemiesSpawnInfo))
                await SpawnEnemy(EnemyType.UniqueEnemy);
            
            if (TryToSpawn(_enemySpawnerConfig.CommonEnemiesSpawnInfo))
                await SpawnEnemy(EnemyType.CommonEnemy);
        }
        
        private bool TryToSpawn(EnemySpawnInfo enemySpawnInfo)
        {
            float random = Random.Range(0, 101);
            
            return enemySpawnInfo.ChanceToSpawnEnemy >= random &&
                   _playTimer.TotalTimeInSeconds > enemySpawnInfo.TimeBeforeSpawnEnemy;
        }

        private async UniTask SpawnEnemy(EnemyType enemyType)
        {
            IEnemy enemy = await _enemyPool.Take(enemyType);
            
            enemy.Character.CharacterInjuring.Health.Heal(float.MaxValue);
            enemy.SubscribeToEvents();
            
            enemy.Character.CharacterPrefab.transform.position = await GetRandomPositionToSpawn();
        }

        private async UniTask<Vector3> GetRandomPositionToSpawn()
        {
            float spawnRadius = _enemySpawnerConfig.SpawnRadius;
            
            float minimumDistanceFromPlayer = _enemySpawnerConfig.MinimumDistanceFromPlayer;
            
            Vector2 randomPosition = Random.insideUnitCircle * spawnRadius;

            float distance = -(_playerProvider.CharacterLocation.CurrentPosition().magnitude - randomPosition.magnitude);
            
            if (Mathf.Abs(distance) >= Mathf.Abs(minimumDistanceFromPlayer))
               return new Vector3(randomPosition.x, OnGround, randomPosition.y);

            return await GetRandomPositionToSpawn();
        }

        public void Initialize() => _enemySpawnerProvider.SetEnemySpawnerToProvider(this);
    }
}