using Cysharp.Threading.Tasks;
using Infrastructure.Gameplay.Persons.PlayerControlled.CameraControl;
using UnityEngine;

namespace Infrastructure.Factories.PlayerFactories
{
    public interface IPlayerCameraFactory
    {
        UniTask<PlayerCamera> Create(GameObject playerPrefab);
    }
}