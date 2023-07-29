using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Infrastructure.Addressable.Loader
{
    public interface IAddressableLoader
    {
        public UniTask<GameObject> LoadGameObject(AssetReferenceGameObject assetReferenceGameObject);

        public UniTask<T> LoadComponent<T>(AssetReferenceGameObject assetReferenceGameObject) where T : Component;

        public void ClearCache();
    }
}