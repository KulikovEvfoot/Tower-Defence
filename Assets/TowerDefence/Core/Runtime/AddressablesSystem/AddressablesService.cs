using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace TowerDefence.Core.Runtime.AddressablesSystem
{
    public class AddressablesService
    {
        private readonly AddressablesLoader m_AddressablesLoader;

        public async UniTask<T> LoadAsync<T>(IKeyEvaluator assetId) where T : Object
        {
            return await m_AddressablesLoader.LoadAsync<T>(assetId);
        }
        
        public T LoadSync<T>(IKeyEvaluator assetId) where T : Object
        {
            return m_AddressablesLoader.LoadSync<T>(assetId);
        }

        public void Unload(Object asset)
        {
            m_AddressablesLoader.Unload(asset);
        }
    }
}