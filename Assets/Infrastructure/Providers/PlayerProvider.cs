using Cysharp.Threading.Tasks;
using Infrastructure.Gameplay.Persons.PlayerControlled;
using UnityEngine;

namespace Infrastructure.Providers
{
    public class PlayerProvider : IPlayerProvider
    {
        private Player _currentPlayer;
        private Transform _playerTransform;
        

        public async UniTask<Player> GetPlayerFromProvider()
        {
            await UniTask.WaitUntil(() => _currentPlayer != null);
            
            return _currentPlayer;
        }

        public async UniTask<Vector3> GetPlayerCurrentPosition()
        {
            await UniTask.WaitUntil(() => _playerTransform != null);

            return _playerTransform.position;
        }

        public void SetPlayerToProvider(Player player) => _currentPlayer = player;

        public void SetPlayerTransformToProvider(Transform playerTransform)
        {
            _playerTransform = playerTransform;
        }
    }
}