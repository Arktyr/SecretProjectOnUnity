using Cysharp.Threading.Tasks;
using Infrastructure.Creation;

namespace Infrastructure.Providers
{
    public interface ILevelDataProvider
    {
        public UniTask<ILevelObjectFactory> GetLevelObjectFactory();
        
        public void SetLevelObjectFactory(ILevelObjectFactory iLevelObjectFactory);

    }
}