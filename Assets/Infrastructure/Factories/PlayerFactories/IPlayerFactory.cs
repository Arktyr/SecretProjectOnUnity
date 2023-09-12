using Cysharp.Threading.Tasks;
using Infrastructure.Gameplay.Persons.PlayerControlled;

namespace Infrastructure.Factories.PlayerFactories
{
    public interface IPlayerFactory
    {
        UniTask WarmUp();
        UniTask<Player> Create();
    }
}