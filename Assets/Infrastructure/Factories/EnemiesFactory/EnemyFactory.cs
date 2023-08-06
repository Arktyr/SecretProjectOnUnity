using Cysharp.Threading.Tasks;
using Infrastructure.Addressable.Loader;
using Infrastructure.Factories.CharactersFactory;
using Infrastructure.Gameplay.Persons.AnyCharacter;
using Infrastructure.Gameplay.Persons.PlayerUncontrolled;
using Infrastructure.Instatiator;
using Infrastructure.Static_Data.Configs.Enemy;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Infrastructure.Factories.EnemiesFactory
{
    public class EnemyFactory : IEnemyFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly ICharacterFactory _characterFactory;
        private readonly IAddressableLoader _addressableLoader;
        

        public EnemyFactory(IInstantiator instantiator,
            ICharacterFactory characterFactory,
            IAddressableLoader addressableLoader)
        {
            _instantiator = instantiator;
            _characterFactory = characterFactory;
            _addressableLoader = addressableLoader;
       
        }
        
        public async UniTask<IEnemy> CreateUniqueEnemy(EnemyConfig enemyConfig)
        {
            return null;
        }

        public async UniTask<IEnemy> CreateRareEnemy(EnemyConfig enemyConfig)
        {
            return null;
        }

        public async UniTask<IEnemy> CreateUncommonEnemy(EnemyConfig enemyConfig)
        {
            return null;
        }

        public async UniTask<IEnemy> CreateCommonEnemy(EnemyConfig enemyConfig)
        {
            GameObject enemyPrefab = await CreatePrefab(enemyConfig.EnemyAddress);
            
            ICharacter character = _characterFactory.Create(enemyPrefab, enemyConfig.CharacterData);

            IEnemy enemy = CreateEnemy(character, enemyConfig.EnemyType);

            HauntEnemy commonHauntEnemy = _instantiator.Instantiate<HauntEnemy>();
            
            commonHauntEnemy.Construct(enemy);

            return enemy;
        }

        private IEnemy CreateEnemy(ICharacter character, EnemyType enemyType)
        {
            Enemy enemy = _instantiator.Instantiate<Enemy>();
            
            enemy.Construct(character, enemyType);

            return enemy;
        }

        private async UniTask<GameObject> CreatePrefab(AssetReferenceGameObject enemy)
        {
            GameObject enemyPrefab = await _addressableLoader.LoadGameObject(enemy);
           
            return _instantiator.InstantiatePrefab(enemyPrefab);
        }
    }
}