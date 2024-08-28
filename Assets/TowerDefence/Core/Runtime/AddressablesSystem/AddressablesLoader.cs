using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace TowerDefence.Core.Runtime.AddressablesSystem
{
    public class AddressablesLoader
    {
        public async UniTask<T> LoadAsync<T>(IKeyEvaluator assetId) where T : Object
        {
            UniTask<T> handle = Addressables.LoadAssetAsync<T>(assetId).ToUniTask();
            T result = await handle;
            return result;
        }
        
        public T LoadSync<T>(IKeyEvaluator assetId) where T : Object
        {
            T waitForCompletion = Addressables.LoadAssetAsync<T>(assetId).WaitForCompletion();
            return waitForCompletion;
        }

        public void Unload(Object asset)
        {
            Addressables.Release(asset);
        }
    }

    //TODO: обертка для последующего расширения. Добавить кеширование
}