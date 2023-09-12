using Cysharp.Threading.Tasks;
using Infrastructure.Addressable.WarmUp;
using Infrastructure.Creation;
using UnityEngine;

namespace Infrastructure.Providers
{
    public interface ILevelDataProvider
    {
        public UniTask<ILevelObjectFactory> GetLevelObjectFactory();
        public void SetLevelObjectFactory(ILevelObjectFactory iLevelObjectFactory);
        public UniTask<GameObject> GetCamera();
        public void SetCamera(GameObject cameraPrefab);
        public UniTask<IWarmUpper> GetLevelWarmUpper();

        public void SetLevelWarmUpper(IWarmUpper levelWarmUpper);
    }
}