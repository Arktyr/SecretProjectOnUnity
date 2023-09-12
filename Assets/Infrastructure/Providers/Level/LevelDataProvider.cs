using Cysharp.Threading.Tasks;
using Infrastructure.Addressable.WarmUp;
using Infrastructure.Creation;
using UnityEngine;

namespace Infrastructure.Providers
{
    public class LevelDataProvider  : ILevelDataProvider
    {
        private ILevelObjectFactory _levelObjectFactory;
        private GameObject _cameraPrefab;
        private IWarmUpper _levelWarmUpper;
        
        public async UniTask<ILevelObjectFactory> GetLevelObjectFactory()
        {
            await UniTask.WaitUntil(() => _levelObjectFactory != null);
            return _levelObjectFactory;
        }

        public void SetLevelObjectFactory(ILevelObjectFactory levelObjectFactory) =>
            _levelObjectFactory = levelObjectFactory;
        
        public async UniTask<GameObject> GetCamera()
        {
            await UniTask.WaitUntil(() => _cameraPrefab!= null);
            return _cameraPrefab;
        }

        public void SetCamera(GameObject cameraPrefab) =>
            _cameraPrefab = cameraPrefab;

        public async UniTask<IWarmUpper> GetLevelWarmUpper()
        {
            await UniTask.WaitUntil(() => _levelWarmUpper!= null);
            return _levelWarmUpper;
        }

        public void SetLevelWarmUpper(IWarmUpper levelWarmUpper) => 
            _levelWarmUpper = levelWarmUpper;
    }
}