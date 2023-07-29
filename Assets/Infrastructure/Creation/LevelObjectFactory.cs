using Cysharp.Threading.Tasks;
using Infrastructure.Factories;
using Infrastructure.Factories.PlayerFactories;
using Infrastructure.Factories.UIFactories;
using Infrastructure.Providers;
using UnityEngine;

namespace Infrastructure.Creation
{
    public class LevelObjectFactory : ILevelObjectFactory
    {
        private readonly IPlayerFactory _playerFactory;
        private readonly IUIFactory _uiFactory;
        private readonly ILevelDataProvider _levelDataProvider;

        public LevelObjectFactory(IPlayerFactory playerFactory,
            ILevelDataProvider levelDataProvider,
            IUIFactory uiFactory)
        {
            _playerFactory = playerFactory;
            _levelDataProvider = levelDataProvider;
            _uiFactory = uiFactory;
        }

        public void Initialize() => SetSelfToProvider();
        
        public async UniTask CreateAllObjects()
        {
           await _playerFactory.Create();
        }
        
        public async UniTask CreateAllUIObjects()
        {
            await _uiFactory.Create();
        }
        
        
        private void SetSelfToProvider() => _levelDataProvider.SetLevelObjectFactory(this);
    }
}