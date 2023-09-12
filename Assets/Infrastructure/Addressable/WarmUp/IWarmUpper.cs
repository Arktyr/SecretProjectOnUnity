using Cysharp.Threading.Tasks;
using IInitializable = Zenject.IInitializable;

namespace Infrastructure.Addressable.WarmUp
{
    public interface IWarmUpper : IInitializable
    {
        public UniTask WarmUp();
    }
}