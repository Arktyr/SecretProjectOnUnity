﻿using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Infrastructure.Addressable.Loader
{
    public class AddressableLoader : IAddressableLoader
    {
        private readonly Dictionary<string, AsyncOperationHandle> _cachedAssets = new();
        
        public async UniTask<GameObject> LoadGameObject(AssetReferenceGameObject assetReferenceGameObject)
        {
            if (assetReferenceGameObject.RuntimeKeyIsValid() == false) 
                Debug.LogError($"{assetReferenceGameObject} - is null");

            string assetID = assetReferenceGameObject.AssetGUID;

            if (_cachedAssets.ContainsKey(assetID))
                return (GameObject)_cachedAssets[assetID].Result;

            var assetHandle = Addressables.LoadAssetAsync<GameObject>(assetReferenceGameObject);
            await assetHandle;
            
            _cachedAssets.Add(assetID, assetHandle);
            
            return assetHandle.Result;
        }

        public async UniTask<T> LoadComponent<T>(AssetReferenceGameObject assetReference) where T: Component
        {
            GameObject gameObject = await LoadGameObject(assetReference);

            if (gameObject.TryGetComponent(out T component)) return component;
            
            Debug.LogError($"{nameof(component)}, doesn't exist");

            return null;
        }

        public void ClearCache()
        {
            foreach (var asyncHandle in _cachedAssets) 
                Addressables.Release(asyncHandle);
            
            _cachedAssets.Clear();
        }
    }
}