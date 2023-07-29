using System;
using Cinemachine;
using Infrastructure.CodeBase.Services.InputService.Base;
using UnityEngine;

namespace Infrastructure.Gameplay.Persons.PlayerControlled.CameraControl
{
    public class PlayerCamera : IDisposable
    {
        private readonly IInputService _inputService;
        
        private IPlayerCameraZoom _playerCameraZoom;
        private IPlayerCameraMove _playerCameraMove;
        private CinemachineVirtualCamera _cinemachineVirtualCamera;
        
        private Transform _playerTransform;
        
        public PlayerCamera(IInputService inputService)
        {
            _inputService = inputService;
        }

        public void Construct(IPlayerCameraZoom playerCameraZoom
            , IPlayerCameraMove playerCameraMove,
            CinemachineVirtualCamera cinemachineVirtualCamera)
        {
            _playerCameraZoom = playerCameraZoom;
            _playerCameraMove = playerCameraMove;
            _cinemachineVirtualCamera = cinemachineVirtualCamera;

            _playerTransform = _cinemachineVirtualCamera.Follow;
            
            SubscribeToInputEvents();
        }

        private void SubscribeToInputEvents()
        {
            _inputService.PlayerCameraZoomInput.InputZoomHappened += _playerCameraZoom.Zoom;
            _inputService.PlayerCameraMoveInput.InputCameraMoveHappened += _playerCameraMove.Move;
            _inputService.PlayerCameraMoveInput.InputCameraMoveEnded += SetFollow;
            _inputService.PlayerCameraMoveInput.InputCameraMoveEnded += _playerCameraMove.ResetPositions;
        }

        private void UnsubscribeFromInputEvent()
        {
            _inputService.PlayerCameraZoomInput.InputZoomHappened -= _playerCameraZoom.Zoom;
            _inputService.PlayerCameraMoveInput.InputCameraMoveHappened -= _playerCameraMove.Move;
            _inputService.PlayerCameraMoveInput.InputCameraMoveEnded -= SetFollow;
            _inputService.PlayerCameraMoveInput.InputCameraMoveEnded -= _playerCameraMove.ResetPositions;
        }


        private void SetFollow() => _cinemachineVirtualCamera.Follow = _playerTransform;

        public void Dispose()
        {
            UnsubscribeFromInputEvent();
        }
    }
}