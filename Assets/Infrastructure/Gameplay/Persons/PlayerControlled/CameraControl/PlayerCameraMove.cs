using System.Numerics;
using Cinemachine;
using Infrastructure.Providers;
using Infrastructure.Providers.Common;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

namespace Infrastructure.Gameplay.Persons.PlayerControlled.CameraControl
{
    public class PlayerCameraMove : IPlayerCameraMove
    {
        private CinemachineVirtualCamera _cinemachineVirtualCamera;
        private ICommonUIProvider _commonUIProvider;

        private GameObject _emptyObject;

        private Vector3 _cinemachinePosition;
        private Vector3 _playerPosition;

        private const float MaxMove = 3;
        private const float MaxTouchDistance = 600;
   
        private Vector2 _canvasCentre;
        
        public PlayerCameraMove(ICommonUIProvider uiProvider)
        {
            _commonUIProvider = uiProvider;
        }

        public async void Construct(CinemachineVirtualCamera cinemachineVirtualCamera,
            GameObject emptyObject)
        {
            _cinemachineVirtualCamera = cinemachineVirtualCamera;
            _emptyObject = emptyObject;

            Canvas canvas = await _commonUIProvider.GetCanvasFromProvider();
            _canvasCentre = canvas.transform.position;
        }

        public void ResetPositions()
        {
            _emptyObject.SetActive(false);
            _cinemachinePosition = Vector3.zero;
        } 

        public void Move(Vector2 touchPosition)
        {
            if (TryBlockTouch(touchPosition)) return;

            _emptyObject.SetActive(true);
            
            if (_cinemachinePosition == Vector3.zero)
            {
                _cinemachinePosition = _cinemachineVirtualCamera.transform.position;
                _playerPosition = _cinemachineVirtualCamera.Follow.position;
            }
            
            _emptyObject.transform.position = GetMoveCoordinates(touchPosition);
            
            _cinemachineVirtualCamera.Follow = _emptyObject.transform;
        }

        private bool TryBlockTouch(Vector2 touchPosition) =>
            Mathf.Abs(_canvasCentre.magnitude - touchPosition.magnitude) > MaxTouchDistance;

        private Vector3 GetMoveCoordinates(Vector2 touchPosition)
        {
            float moveX = Mathf.Clamp(_playerPosition.x - (_canvasCentre.x - touchPosition.x) * Time.fixedDeltaTime,
                _playerPosition.x - MaxMove, _playerPosition.x + MaxMove);
            
            float moveZ = Mathf.Clamp(_playerPosition.z - (_canvasCentre.y - touchPosition.y) * Time.fixedDeltaTime, 
                _playerPosition.z - MaxMove, _cinemachinePosition.z + MaxMove);

            return new Vector3(moveX, 0, moveZ);
        }
    }
}