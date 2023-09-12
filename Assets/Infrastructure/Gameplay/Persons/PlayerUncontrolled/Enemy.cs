using System;
using Infrastructure.CodeBase.Services.Update;
using Infrastructure.Gameplay.Persons.AnyCharacter;
using UnityEngine;

namespace Infrastructure.Gameplay.Persons.PlayerUncontrolled
{
    public class Enemy : IEnemy
    {
        public ICharacter Character { get; private set; }
        public EnemyType EnemyType { get; private set; }

        public event Action<IEnemy> Died;
        public event Action Updated;

        private readonly IUpdaterService _updaterService;

        public Enemy(IUpdaterService updaterService)
        {
            _updaterService = updaterService;
        }

        public void Construct(ICharacter character, 
            EnemyType enemyType)
        {
            Character = character;
            EnemyType = enemyType;
        }

        private void Update(float time) => Updated?.Invoke();

        private void Die() => Dispose();

        public void SubscribeToEvents()
        {
            Character.CharacterInjuring.Health.Died += Die;
            Character.CharacterInjuring.SubscribeToEvents();
            _updaterService.FixedUpdate += Update;
        }

        private void UnSubscribeFromEvents()
        {
            Character.CharacterInjuring.Health.Died -= Die;
            _updaterService.FixedUpdate -= Update;
        }

        public void Dispose()
        {
            UnSubscribeFromEvents();
            Died?.Invoke(this);
        }
    }
}