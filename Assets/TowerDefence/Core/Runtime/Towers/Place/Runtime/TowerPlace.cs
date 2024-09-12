using System;
using Common;
using Cysharp.Threading.Tasks;
using TowerDefence.Core.Runtime.AddressablesSystem;
using TowerDefence.Core.Runtime.Config;
using TowerDefence.Core.Runtime.Towers.Rifle.Runtime;
using TowerDefence.Core.Runtime.Towers.Rifle.Runtime.Balance;
using UnityEngine;

namespace TowerDefence.Core.Runtime.Towers.Place.Runtime
{
    public class TowerPlaceService : ITowerService
    {
        private readonly ILogger m_Logger;
        private readonly AddressablesService m_AddressablesService;
        private readonly ILocationBalanceFacade m_LocationBalanceFacade;
        
        private TowerPlaceFactory m_TowerPlaceFactory;
        
        private GameObject m_TowerPlaceAsset;

        public string Key => TowerPlaceEnvironment.Key;

        public TowerPlaceService(AddressablesService addressablesService, ILocationBalanceFacade locationBalanceFacade)
        {
            m_AddressablesService = addressablesService;
            m_LocationBalanceFacade = locationBalanceFacade;
        }

        public async UniTask Preload()
        {
            var towerPlaceBalanceAsset = await m_AddressablesService.LoadAsync<TextAsset>("balance_tower_place");
            if (towerPlaceBalanceAsset == null)
            {
                m_Logger.Log(LogType.Error, $"Error when loading {nameof(TowerPlaceView)}");
                return;
            }
            
            var configResult = Serializer.Deserialize<TowerPlaceConfig>(towerPlaceBalanceAsset.text);
            if (!configResult.IsExist)
            {
                m_Logger.Log(LogType.Error, $"Error when loading {nameof(TowerPlaceView)}");
                return;
            }
            
            var towerPlaceBalance = configResult.Object;
            m_TowerPlaceAsset = await m_AddressablesService.LoadAsync<GameObject>(towerPlaceBalance.ViewAddress);
            if (m_TowerPlaceAsset == null)
            {
                m_Logger.Log(LogType.Error, $"Error when loading {nameof(TowerPlaceView)}");
                return;
            }
        }

        public void Init()
        {
            m_TowerPlaceFactory = new TowerPlaceFactory(m_TowerPlaceAsset, m_LocationBalanceFacade);
        }

        public ITowerFactory GetFactory()
        {
            return m_TowerPlaceFactory;
        }
    }

    
    public class TowerPlace : ITower
    {
    
    }
}
