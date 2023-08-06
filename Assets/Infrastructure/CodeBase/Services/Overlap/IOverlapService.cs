using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure.CodeBase.Services.Overlap
{
    public interface IOverlapService
    {
        public Collider[] BoxOverlap(Vector3 center, Vector3 halfExtends, Quaternion rotation);

        public Collider[] CapsuleOverlap(Vector3 position0, Vector3 position1, float radius);

        public Collider[] SphereOverlap(Vector3 position, float radius);

        public List<T> OverlapForComponent<T>(Collider[] colliders) where T : Component;
    }
}