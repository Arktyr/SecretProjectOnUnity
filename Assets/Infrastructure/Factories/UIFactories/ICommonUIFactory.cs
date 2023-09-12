using Cysharp.Threading.Tasks;
using Infrastructure.Addressable.WarmUp;

namespace Infrastructure.Factories.UIFactories
{
    public interface ICommonUIFactory
    {
        public UniTask WarmUp();
        public UniTask Create();
    }
}