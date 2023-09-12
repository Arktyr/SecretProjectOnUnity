using Cysharp.Threading.Tasks;
using Infrastructure.Gameplay.Persons.PlayerUncontrolled;

namespace Infrastructure.Gameplay.Spawner
{
    public interface IEnemyPool
    {
        public UniTask<IEnemy> Take(EnemyType enemyType);

        public void ClearPool();
    }
}