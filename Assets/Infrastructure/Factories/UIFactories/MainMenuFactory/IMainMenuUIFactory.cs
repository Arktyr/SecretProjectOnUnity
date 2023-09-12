using Cysharp.Threading.Tasks;
using Zenject;

namespace Infrastructure.Factories
{
    public interface IMainMenuUIFactory : IInitializable
    {
        public UniTask CreateMainMenu();
    }
}