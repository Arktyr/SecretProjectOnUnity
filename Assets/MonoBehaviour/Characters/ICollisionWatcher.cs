using System;
using UnityEngine;

namespace Infrastructure.Gameplay.Persons.Common.Abilities
{
    public interface ICollisionWatcher
    {
        public event Action<Collider> CollisionEntered;
        public event Action<Collider> CollisionExited;
        public event Action<Collider> CollisionStayed;
        
        public event Action<Collider> TriggerEntered;
        public event Action<Collider> TriggerExited;
        public event Action<Collider> TriggerStayed;
    }
}