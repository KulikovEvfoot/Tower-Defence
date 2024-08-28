using System.Collections.Generic;
using Common;
using Common.Logger;
using Cysharp.Threading.Tasks;
using TowerDefence.Core.Runtime.AddressablesSystem;
using TowerDefence.Core.Runtime.Config;
using TowerDefence.Core.Runtime.Towers.Rifle.Runtime.Balance;
using UnityEngine;

namespace TowerDefence.Core.Runtime.Towers.Rifle.Runtime
{
    public class RifleTowerService : ITowerService
    {
        private readonly AddressablesService m_AddressablesService;
        private readonly UpdateMaster m_UpdateMaster;
        private readonly ILogger m_Logger;
        
        private TowerFactoryProvider m_TowerFactoryProvider;
        private GameObject m_CrossbowTowerViewAsset;

        public string Key => RifleTowerEnvironment.Key;
        
        public RifleTowerService(
            AddressablesService addressablesService,
            UpdateMaster updateMaster)
        {
            m_Logger = Debug.unityLogger.WithPrefix($"[{nameof(RifleTowerService)}]: ");

            m_AddressablesService = addressablesService;
            m_UpdateMaster = updateMaster;
        }

        //TODO: отрефакторить добавление новых подтипов
        public async UniTask Preload()
        {
            const string crossbowKey = RifleTowerEnvironment.CrossbowSubtype;
            
            var crossbowTowerBalanceAsset = await m_AddressablesService.LoadAsync<TextAsset>("balance_crossbow_tower");
            if (crossbowTowerBalanceAsset == null)
            {
                m_Logger.Log(LogType.Error, $"Error when loading {crossbowKey}");
                return;
            }
            
            var configResult = Serializer.Deserialize<CrossbowTowerConfig>(crossbowTowerBalanceAsset.text);
            if (!configResult.IsExist)
            {
                m_Logger.Log(LogType.Error, $"Error when loading {crossbowKey}");
                return;
            }
            
            var crossbowTowerBalance = configResult.Object;
            m_CrossbowTowerViewAsset = await m_AddressablesService.LoadAsync<GameObject>(crossbowTowerBalance.ViewAddress);
            if (m_CrossbowTowerViewAsset == null)
            {
                m_Logger.Log(LogType.Error, $"Error when loading {crossbowKey} tower");
                return;
            }
        }

        public void Init(ILocationBalanceFacade locationBalanceFacade)
        {
            var towerFactoriesMap = new Dictionary<string, ITowerFactory>();
            
            var crossbowFactory = new CrossbowTowerFactory(
                m_CrossbowTowerViewAsset,
                locationBalanceFacade,
                m_UpdateMaster);

            towerFactoriesMap.Add(RifleTowerEnvironment.CrossbowSubtype, crossbowFactory);
            
            m_TowerFactoryProvider = new TowerFactoryProvider(towerFactoriesMap);
        }

        public ITowerFactory GetFactory()
        {
            return m_TowerFactoryProvider;
        }
    }
}