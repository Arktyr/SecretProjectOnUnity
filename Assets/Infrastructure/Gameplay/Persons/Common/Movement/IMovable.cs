using UnityEngine;

namespace Infrastructure.Gameplay.Persons.Common.Movement
{
    public interface IMovable
    {
        void Move(Vector2 direction);
    }
}