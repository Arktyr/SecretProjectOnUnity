using Cysharp.Threading.Tasks;
using Infrastructure.Creation;
using Zenject;

namespace Infrastructure.Providers
{
    public class LevelDataProvider  : ILevelDataProvider
    {
        private ILevelObjectFactory _levelObjectFactory;
        
        public async UniTask<ILevelObjectFactory> GetLevelObjectFactory()
        {
            await UniTask.WaitUntil(() => _levelObjectFactory != null);
            return _levelObjectFactory;
        }

        public void SetLevelObjectFactory(ILevelObjectFactory iLevelObjectFactory)
        {
            _levelObjectFactory = iLevelObjectFactory;
        }
    }
}