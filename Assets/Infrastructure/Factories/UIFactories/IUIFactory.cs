using Cysharp.Threading.Tasks;

namespace Infrastructure.Factories.UIFactories
{
    public interface IUIFactory
    {
        public UniTask Create();
    }
}