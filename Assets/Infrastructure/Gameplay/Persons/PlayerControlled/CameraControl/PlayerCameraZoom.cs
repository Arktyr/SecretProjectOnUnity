using Cinemachine;
using UnityEngine;

namespace Infrastructure.Gameplay.Persons.PlayerControlled.CameraControl
{
    public class PlayerCameraZoom : IPlayerCameraZoom
    {
        private CinemachineVirtualCamera _cinemachineCamera;

        private const float MaxZoom = 60;
        private const float MinZoom = 20;
        
        public void Construct(CinemachineVirtualCamera cinemachineCamera)
        {
            _cinemachineCamera = cinemachineCamera;
        }
        
        public void Zoom(float value)
        {
            float currentZoom = _cinemachineCamera.m_Lens.FieldOfView - value;
            
            _cinemachineCamera.m_Lens.FieldOfView = Mathf.Clamp(currentZoom, MinZoom, MaxZoom);
        }
    }
}