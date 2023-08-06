using System;
using Infrastructure.Gameplay.Persons.AnyCharacter;

namespace Infrastructure.Gameplay.Persons.PlayerUncontrolled
{
    public interface IEnemy
    {
        public EnemyType EnemyType { get;}
        public ICharacter Character { get; }

        public event Action<IEnemy> Died;

        public event Action Updated;
        public void SubscribeToEvents();
    }
}