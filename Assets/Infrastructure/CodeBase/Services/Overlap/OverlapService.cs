using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure.CodeBase.Services.Overlap
{
    public class OverlapService : IOverlapService
    {
        public Collider[] BoxOverlap(Vector3 center, Vector3 halfExtends, Quaternion rotation) =>
            Physics.OverlapBox(center, halfExtends, rotation);
        
        public Collider[] CapsuleOverlap(Vector3 position0, Vector3 position1, float radius) =>
            Physics.OverlapCapsule(position0, position1, radius);
        
        public Collider[] SphereOverlap(Vector3 position, float radius) => Physics.OverlapSphere(position, radius);

        public List<T> OverlapForComponent<T>(Collider[] colliders) where T : Component
        {
            List<T> components = new List<T>();

            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].TryGetComponent(out T component)) components.Add(component);
            }

            return components;
        }
    }
}