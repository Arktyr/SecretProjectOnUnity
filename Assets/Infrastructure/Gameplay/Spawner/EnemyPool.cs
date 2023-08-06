using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Infrastructure.Factories.EnemiesFactory;
using Infrastructure.Gameplay.Persons.PlayerUncontrolled;
using Infrastructure.Providers;
using Infrastructure.Static_Data.Configs.Enemy;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Infrastructure.Gameplay.Spawner
{
    public class EnemyPool : IEnemyPool
    {
        private readonly List<IEnemy> _enemies = new();
        private readonly List<IEnemy> _activeEnemies = new();

        private readonly IEnemyFactory _enemyFactory;
        private readonly IStaticDataProvider _staticDataProvider;

        public EnemyPool(IEnemyFactory enemyFactory,
            IStaticDataProvider staticDataProvider)
        {
            _enemyFactory = enemyFactory;
            _staticDataProvider = staticDataProvider;
        }
        
        public async UniTask<IEnemy> Take(EnemyType enemyType)
        {
            foreach (var enemy in _enemies)
            {
                if (enemy.EnemyType == enemyType)
                {
                    _enemies.Remove(enemy);
                    _activeEnemies.Add(enemy);
                    enemy.Died += ReturnToPool;
                    enemy.Character.CharacterPrefab.SetActive(true);
                    return enemy;
                }
            }

            await AddToPool(enemyType);
            
            return await Take(enemyType);
        }

        private void ReturnToPool(IEnemy character)
        {
            character.Died -= ReturnToPool;
            
            character.Character.CharacterPrefab.SetActive(false);
            
            _enemies.Add(character);
            _activeEnemies.Remove(character);
        }

        private async UniTask AddToPool(EnemyType enemyType)
        {
            switch (enemyType)
            {
                case EnemyType.CommonEnemy:
                {
                    IEnemy enemy = await _enemyFactory.CreateCommonEnemy(
                        GetRandomEnemyConfig(_staticDataProvider.LevelData.AllEnemiesOnLevelData.CommonEnemies));
                    _enemies.Add(enemy);
                    enemy.Character.CharacterPrefab.SetActive(false);
                    break;
                }
                case EnemyType.UncommonEnemy:
                {
                    IEnemy enemy = await _enemyFactory.CreateUncommonEnemy(
                        GetRandomEnemyConfig(_staticDataProvider.LevelData.AllEnemiesOnLevelData.UncommonEnemies));
                    _enemies.Add(enemy);
                    enemy.Character.CharacterPrefab.SetActive(false);
                    break;
                }
                case EnemyType.RareEnemy:
                {
                    IEnemy enemy = await _enemyFactory.CreateRareEnemy(
                        GetRandomEnemyConfig(_staticDataProvider.LevelData.AllEnemiesOnLevelData.RareEnemies));
                    _enemies.Add(enemy);
                    enemy.Character.CharacterPrefab.SetActive(false);
                    break;
                }
                case EnemyType.UniqueEnemy:
                {
                    IEnemy enemy = await _enemyFactory.CreateUniqueEnemy(
                        GetRandomEnemyConfig(_staticDataProvider.LevelData.AllEnemiesOnLevelData.UniqueEnemies));
                    _enemies.Add(enemy);
                    enemy.Character.CharacterPrefab.SetActive(false);
                    break;
                }
                default:
                    Debug.LogError("something wrong with AddToPool");
                    break;
            }
        }

        private EnemyConfig GetRandomEnemyConfig(EnemyConfig[] enemyConfigs)
        {
            int random = Random.Range(0, enemyConfigs.Length);
            
            return enemyConfigs[random];
        }
    }
}