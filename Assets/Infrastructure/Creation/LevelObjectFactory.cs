using Cysharp.Threading.Tasks;
using Infrastructure.Factories;
using Infrastructure.Factories.EnemiesFactory;
using Infrastructure.Factories.PlayerFactories;
using Infrastructure.Factories.UIFactories;
using Infrastructure.Gameplay.Spawner;
using Infrastructure.Providers;
using UnityEngine;

namespace Infrastructure.Creation
{
    public class LevelObjectFactory : ILevelObjectFactory
    {
        private readonly IPlayerFactory _playerFactory;
        private readonly IUIFactory _uiFactory;
        private readonly ILevelDataProvider _levelDataProvider;
        private readonly IEnemySpawner _enemySpawner;

        public LevelObjectFactory(IPlayerFactory playerFactory,
            ILevelDataProvider levelDataProvider,
            IUIFactory uiFactory,
            IEnemySpawner enemySpawner)
        {
            _playerFactory = playerFactory;
            _levelDataProvider = levelDataProvider;
            _uiFactory = uiFactory;
            _enemySpawner = enemySpawner;
        }

        public void Initialize() => SetSelfToProvider();
        
        public async UniTask CreateAllObjects()
        {
           await _playerFactory.Create();
           _enemySpawner.StartSpawnEnemies();
        }
        
        public async UniTask CreateAllUIObjects()
        {
            await _uiFactory.Create();
        }
        
        
        private void SetSelfToProvider() => _levelDataProvider.SetLevelObjectFactory(this);
    }
}