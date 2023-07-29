using UnityEngine;

namespace Infrastructure.Gameplay.Persons.Common.Abilities
{
    public class Teleport : ITeleport
    {
        private Transform _entity;
        
        private Vector3 _mapSize;
        
        public void Construct(Transform entity,
            Vector3 mapSize)
        {
            _entity = entity;
            _mapSize = mapSize;
        }
        
        public void Teleportation(Vector3 position)
        {
            if (CheckExitOutOfBounds(position)) return;

            _entity.position = position;
        }

        public void TeleportationForward(Vector3 position)
        {
            if (CheckExitOutOfBounds(position)) return;
            
            _entity.position += position;
        }

        private bool CheckExitOutOfBounds(Vector3 currentTeleportPosition)
        {
            Vector3 previewCharacterPosition = currentTeleportPosition + _entity.transform.position;

            return _mapSize.x < previewCharacterPosition.x ||
                   -_mapSize.x > previewCharacterPosition.x ||
                   _mapSize.z < previewCharacterPosition.z ||
                   -_mapSize.z > previewCharacterPosition.z;
        }
    }
}