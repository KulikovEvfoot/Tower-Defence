using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Object = UnityEngine.Object;

namespace TowerDefence.Core.Runtime.AddressablesSystem
{
    public class AddressablesService
    {
        private readonly AddressablesLoader m_AddressablesLoader = new();

        public async UniTask<T> LoadAsync<T>(IKeyEvaluator assetId) where T : Object
        {
            return await m_AddressablesLoader.LoadAsync<T>(assetId);
        }
        
        public async UniTask<T> LoadAsync<T>(string assetId) where T : Object
        {
            try
            {
                return await m_AddressablesLoader.LoadAsync<T>(new StringKeyEvaluator(assetId));
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }

            return null;
        }
        
        public T LoadSync<T>(IKeyEvaluator assetId) where T : Object
        {
            return m_AddressablesLoader.LoadSync<T>(assetId);
        }
        
        public T LoadSync<T>(string assetId) where T : Object
        {
            return m_AddressablesLoader.LoadSync<T>(new StringKeyEvaluator(assetId));
        }

        public void Unload(Object asset)
        {
            m_AddressablesLoader.Unload(asset);
        }
    }
}