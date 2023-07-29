using UnityEngine;

namespace Infrastructure.Gameplay.Persons.Common.Movement
{
    public interface IRotatable
    {
        void Rotate(Vector2 direction);
    }
}