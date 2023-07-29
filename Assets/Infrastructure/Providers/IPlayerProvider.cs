using Cysharp.Threading.Tasks;
using Infrastructure.Gameplay.Persons.PlayerControlled;
using UnityEngine;

namespace Infrastructure.Providers
{
    public interface IPlayerProvider
    {
        UniTask<Player> GetPlayerFromProvider();
        
        UniTask<Vector3> GetPlayerCurrentPosition();
        
        void SetPlayerToProvider(Player player);

        void SetPlayerTransformToProvider(Transform playerTransform);
    }
}