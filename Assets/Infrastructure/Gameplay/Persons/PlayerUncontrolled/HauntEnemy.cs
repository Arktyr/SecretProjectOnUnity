using System;
using Infrastructure.Providers;
using UnityEngine;

namespace Infrastructure.Gameplay.Persons.PlayerUncontrolled
{
    public class HauntEnemy : IDisposable
    {
        private IEnemy _enemy;
        
        private readonly IPlayerProvider _playerProvider;
        
        public HauntEnemy(IPlayerProvider playerProvider)
        {
            _playerProvider = playerProvider;
        }
        
        public void Construct(IEnemy enemy)
        {
            _enemy = enemy;

            _enemy.Updated += Controlling;
        }
        
        private void Controlling()
        {
            FollowPlayer();
            _enemy.Character.CharacterAbility.TryUseAllAbilities();
        }
        
        private void FollowPlayer()
        {
            Vector3 playerPosition = _playerProvider.CharacterLocation.CurrentPosition();

            Vector3 enemyPosition = _enemy.Character.CharacterMovement.CharacterLocation.CurrentPosition();

            Vector3 characterPosition = new Vector3(enemyPosition.x, 0, enemyPosition.z);

            Vector3 distance = -(characterPosition - playerPosition).normalized;
            
            _enemy.Character.CharacterMovement.Move(distance);
            _enemy.Character.CharacterMovement.Rotate(distance);
        }

        public void Dispose()
        {
            _enemy.Updated -= Controlling;
        }
    }
}