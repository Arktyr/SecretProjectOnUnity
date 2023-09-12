using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Infrastructure.Factories.Camera
{
    public interface ICameraFactory
    {
        public UniTask WarmUp();
        public UniTask<GameObject> CreatePrefabCamera();
    }
}