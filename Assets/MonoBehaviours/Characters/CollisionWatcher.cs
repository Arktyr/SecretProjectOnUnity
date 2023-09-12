using System;
using Infrastructure.Gameplay.Persons.Common.Abilities;
using UnityEngine;

namespace MonoBehaviours.Characters
{
    public class CollisionWatcher : MonoBehaviour, ICollisionWatcher
    {
        public event Action<Collider> CollisionEntered;
        public event Action<Collider> CollisionExited;
        public event Action<Collider> CollisionStayed;
        
        public event Action<Collider> TriggerEntered;
        public event Action<Collider> TriggerStayed;
        public event Action<Collider> TriggerExited;
        
        private void OnCollisionEnter(Collision collision) => CollisionEntered?.Invoke(collision.collider);

        private void OnCollisionExit(Collision collision) => CollisionExited?.Invoke(collision.collider);

        private void OnCollisionStay(Collision collision) => CollisionStayed?.Invoke(collision.collider);

        private void OnTriggerEnter(Collider collision) => TriggerEntered?.Invoke(collision);

        private void OnTriggerExit(Collider collision) => TriggerExited?.Invoke(collision);

        private void OnTriggerStay(Collider collision) => TriggerStayed?.Invoke(collision);
    }
}