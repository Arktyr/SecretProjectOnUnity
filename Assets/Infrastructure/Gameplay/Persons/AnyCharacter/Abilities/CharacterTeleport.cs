using Cysharp.Threading.Tasks;
using Infrastructure.Gameplay.Persons.Common.Abilities;
using UnityEngine;

namespace Infrastructure.Gameplay.Persons.AnyCharacter.Abilities
{
    public class CharacterTeleport : IAbility
    {
        private ICharacterMovement _characterMovement;
        private ITeleport _teleport;

        private int _teleportDelay;
        private float _teleportDistance;

        private bool _isRecharged;
        
        public void Construct(ICharacterMovement characterMovement,
            ITeleport teleport,
            int teleportDelay,
            float teleportDistance)
        {
            _characterMovement = characterMovement;
            _teleport = teleport;
            _teleportDelay = teleportDelay;
            _teleportDistance = teleportDistance;

            _isRecharged = true;
        }
        
        private async void Teleportation()
        {
            Vector2 characterDirection = _characterMovement.Direction;

            Vector3 currentCharacterDirection = new Vector3(characterDirection.x, 0, characterDirection.y);

            currentCharacterDirection *= _teleportDistance;

            _isRecharged = false;
            
            _characterMovement.DisableCharacterController();
            _teleport.TeleportationForward(currentCharacterDirection);
            _characterMovement.EnableCharacterController();

            await TeleportCooldown();
        }
        
        private async UniTask TeleportCooldown()
        {
            int delayInSeconds = _teleportDelay * 1000;
            
            await UniTask.Delay(delayInSeconds);

            _isRecharged = true;
        }

        public void Cast()
        {
            if (_isRecharged) Teleportation();
        }
    }
}