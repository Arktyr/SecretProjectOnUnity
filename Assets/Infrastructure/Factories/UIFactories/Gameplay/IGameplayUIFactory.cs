using Cysharp.Threading.Tasks;

namespace Infrastructure.Factories.UIFactories.Gameplay
{
    public interface IGameplayUIFactory
    {
        public UniTask Create();
    }
}