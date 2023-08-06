using UnityEngine;

namespace Infrastructure.Gameplay.Persons.Common.Abilities
{
    public interface ITeleport
    {
        public void Teleportation(Vector3 position);

        public void TeleportationForward(Vector3 position);
    }
}