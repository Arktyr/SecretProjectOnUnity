using Cinemachine;
using Infrastructure.Providers;
using UnityEngine;

namespace Infrastructure.Gameplay.Persons.PlayerControlled.CameraControl
{
    public class PlayerCameraMove : IPlayerCameraMove
    {
        private CinemachineVirtualCamera _cinemachineVirtualCamera;
        private IUIProvider _uiProvider;

        private Vector3 _cinemachinePosition;
        private Vector3 _playerPosition;

        private const float MaxMove = 3;
   
        private Vector2 _canvasCentre;
        

        public PlayerCameraMove(IUIProvider uiProvider)
        {
            _uiProvider = uiProvider;
        }

        public async void Construct(CinemachineVirtualCamera cinemachineVirtualCamera)
        {
            _cinemachineVirtualCamera = cinemachineVirtualCamera;

            Canvas canvas = await _uiProvider.GetCanvasFromProvider();
            _canvasCentre = canvas.transform.position;
        }
        
        public void ResetPositions() => _cinemachinePosition = Vector3.zero;

        public void Move(Vector2 touchPosition)
        {
            if (_cinemachinePosition == Vector3.zero)
            {
                _cinemachinePosition = _cinemachineVirtualCamera.transform.position;
                _playerPosition = _cinemachineVirtualCamera.Follow.position;
            }
            
            float moveX = Mathf.Clamp(_playerPosition.x - (_canvasCentre.x - touchPosition.x) * Time.fixedDeltaTime,
                _playerPosition.x - MaxMove, _playerPosition.x + MaxMove);
            
            float moveZ = Mathf.Clamp(_playerPosition.z - (_canvasCentre.y - touchPosition.y) * Time.fixedDeltaTime, 
                _playerPosition.z - MaxMove, _cinemachinePosition.z + MaxMove);
            
            _cinemachineVirtualCamera.Follow = null;

            _cinemachineVirtualCamera.transform.position = new Vector3(moveX, _cinemachinePosition.y, moveZ);
        }
    }
}