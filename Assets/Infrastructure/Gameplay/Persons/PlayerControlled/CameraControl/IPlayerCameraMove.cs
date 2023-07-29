using UnityEngine;

namespace Infrastructure.Gameplay.Persons.PlayerControlled.CameraControl
{
    public interface IPlayerCameraMove
    {
        void Move(Vector2 touchPosition);
        
        void ResetPositions();
    }
}