using Cysharp.Threading.Tasks;
using Infrastructure.Gameplay.Persons.Common.Abilities;
using UnityEngine;

namespace Infrastructure.Gameplay.Persons.AnyCharacter.Abilities
{
    public class CharacterTeleportForward : IAbility
    {
        private ICharacterMovement _characterMovement;
        private ITeleport _teleport;
        private ICooldown _cooldown;
        
        private float _teleportDistance;

        public void Construct(ICharacterMovement characterMovement,
            ITeleport teleport,
            ICooldown cooldown,
            float teleportDistance)
        {
            _characterMovement = characterMovement;
            _teleport = teleport;
            _cooldown = cooldown;
            
            _teleportDistance = teleportDistance;
        }
        
        private async void Teleportation()
        {
            Vector2 characterDirection = _characterMovement.CharacterLocation.Direction();

            Vector3 currentCharacterDirection = new Vector3(characterDirection.x, 0, characterDirection.y);

            currentCharacterDirection *= _teleportDistance;
            
            _teleport.TeleportationForward(currentCharacterDirection);

            await _cooldown.StartCooldown();
        }
        
        public  void Use()
        {
            if (_cooldown.IsRecharged) Teleportation();
        }
    }
}